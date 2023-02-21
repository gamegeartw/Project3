using Furion.Reflection;
using System.Reflection;

namespace Project3.Application
{
    /// <summary>
    /// 自訂服務驗證
    /// </summary>
    public class GlobalAuthorizeProxy : AspectDispatchProxy, IGlobalDispatchProxy
    {
        public override object Invoke(MethodInfo method, object[] args)
        {

            var roleAttr = method.CustomAttributes.FirstOrDefault(m => m.AttributeType == typeof(AuthorizeAttribute));
            if (roleAttr != null && App.User == null)
            {
                throw Oops.Oh("未登入或已超過時效");
            }




            return method.Invoke(Target, args);
        }

        public override Task InvokeAsync(MethodInfo method, object[] args)
        {
            return this.Invoke(method, args) as Task;
        }

        public override Task<T> InvokeAsyncT<T>(MethodInfo method, object[] args)
        {
            return this.Invoke(method, args) as Task<T>;
        }

        public object Target { get; set; }
        public IServiceProvider Services { get; set; }
    }
}