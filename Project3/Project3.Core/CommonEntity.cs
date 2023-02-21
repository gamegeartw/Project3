using Furion.DependencyInjection;
using Project3.Core;
using System;

namespace Furion.DatabaseAccessor
{
    public abstract class CommonEntity : CommonEntity<int, MasterDbContextLocator>
    {
    }

    public abstract class CommonEntity<TKey> : CommonEntity<TKey, MasterDbContextLocator>
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2, TDbContextLocator3> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
        where TDbContextLocator3 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2, TDbContextLocator3, TDbContextLocator4> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
        where TDbContextLocator3 : class, IDbContextLocator
        where TDbContextLocator4 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2, TDbContextLocator3, TDbContextLocator4, TDbContextLocator5> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
        where TDbContextLocator3 : class, IDbContextLocator
        where TDbContextLocator4 : class, IDbContextLocator
        where TDbContextLocator5 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2, TDbContextLocator3, TDbContextLocator4, TDbContextLocator5, TDbContextLocator6> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
        where TDbContextLocator3 : class, IDbContextLocator
        where TDbContextLocator4 : class, IDbContextLocator
        where TDbContextLocator5 : class, IDbContextLocator
        where TDbContextLocator6 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2, TDbContextLocator3, TDbContextLocator4, TDbContextLocator5, TDbContextLocator6, TDbContextLocator7> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
        where TDbContextLocator3 : class, IDbContextLocator
        where TDbContextLocator4 : class, IDbContextLocator
        where TDbContextLocator5 : class, IDbContextLocator
        where TDbContextLocator6 : class, IDbContextLocator
        where TDbContextLocator7 : class, IDbContextLocator
    {
    }

    public abstract class CommonEntity<TKey, TDbContextLocator1, TDbContextLocator2, TDbContextLocator3, TDbContextLocator4, TDbContextLocator5, TDbContextLocator6, TDbContextLocator7, TDbContextLocator8> : PrivateCommonEntity<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
        where TDbContextLocator2 : class, IDbContextLocator
        where TDbContextLocator3 : class, IDbContextLocator
        where TDbContextLocator4 : class, IDbContextLocator
        where TDbContextLocator5 : class, IDbContextLocator
        where TDbContextLocator6 : class, IDbContextLocator
        where TDbContextLocator7 : class, IDbContextLocator
        where TDbContextLocator8 : class, IDbContextLocator
    {
    }

    public abstract class PrivateCommonEntity<TKey> : IPrivateEntity, IDelete, ICreate, IUpdate
    {
        // 注意是在这里定义你的公共实体
        public virtual TKey Id { get; set; }

        public virtual DateTime CreatedTime { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? UpdatedTime { get; set; }

        public virtual string UpdatedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        // 更多属性定义
    }
}