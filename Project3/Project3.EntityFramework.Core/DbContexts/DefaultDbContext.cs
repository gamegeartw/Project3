using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project3.Core;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Project3.EntityFramework.Core
{
    [AppDbContext("Data Source=./App_Data/Data.db", DbProvider.Sqlite)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public void OnCreating(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            // 设置软删除表达式
            var fakeDeleteQueryFilterExpression = FakeDeleteQueryFilterExpression(entityBuilder, dbContext);
            if (fakeDeleteQueryFilterExpression == null) return;

            entityBuilder.HasQueryFilter(fakeDeleteQueryFilterExpression);
        }
        /// <summary>
        /// 构建假删除查询过滤器表达式
        /// </summary>
        /// <param name="entityBuilder">实体类型构建器</param>
        /// <param name="dbContext">数据库上下文</param>
        /// <param name="isDeletedKey">软删除属性名</param>
        /// <param name="filterValue">过滤的值</param>
        /// <returns>表达式</returns>
        protected virtual LambdaExpression FakeDeleteQueryFilterExpression(EntityTypeBuilder entityBuilder, DbContext dbContext, string isDeletedKey = default, object filterValue = default)
        {
            isDeletedKey ??= nameof(IDelete.IsDeleted);

            // 获取实体构建器元数据
            var metadata = entityBuilder.Metadata;
            if (metadata.FindProperty(isDeletedKey) == null) return default;

            // 创建表达式元素
            var parameter = Expression.Parameter(metadata.ClrType, "u");
            var properyName = Expression.Constant(isDeletedKey);
            var propertyValue = Expression.Constant(filterValue ?? false);

            var expressionBody = Expression.Equal(Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter, properyName), propertyValue);
            var expression = Expression.Lambda(expressionBody, parameter);
            return expression;
        }

        /// <summary>
        /// 攔截保存事件,寫入創建和修改時間
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        protected override void SavingChangesEvent(DbContextEventData eventData, InterceptionResult<int> result)
        {
            // 获取当前事件对应上下文
            var dbContext = eventData.Context;

            // 获取所有新增和更新的实体
            Debug.Assert(dbContext != null, nameof(dbContext) + " != null");
            var entities = dbContext.ChangeTracker.Entries()
                .Where(u => u.State == EntityState.Added || u.State == EntityState.Modified);

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    // 自动设置租户Id
                    case EntityState.Added:
                        if (entity.Entity is ICreate)
                        {
                            entity.Property("CreatedTime").CurrentValue = DateTime.Now;
                            entity.Property("CreatedBy").CurrentValue = App.User.Identity?.Name ?? "System";
                        }
                        break;
                    // 排除租户Id
                    case EntityState.Modified:
                        if (entity.Entity is IUpdate)
                        {
                            entity.Property("UpdatedTime").CurrentValue = DateTime.Now;
                            entity.Property("UpdatedBy").CurrentValue = App.User.Identity?.Name ?? "System";
                        }
                        break;
                    case EntityState.Deleted:
                        if (entity.Entity is IDelete)
                        {
                            entity.Property("IsDeleted").CurrentValue = true;
                            entity.State = EntityState.Modified;
                        }
                        break;
                }
            }
        }
    }
}