
using Castle.DynamicProxy;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.CrossCuttingConcerns.DependencyResolver.Autofac
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
          
        }

       public virtual void OnBefore(IInvocation invocation) { }
         
    }
}
