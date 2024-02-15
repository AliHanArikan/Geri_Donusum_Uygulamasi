using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreLayer.CrossCuttingConcerns.DependencyResolver.Autofac
{
    public class PerformanceAspect : MethodInterceptionBaseAttribute
    {
        private readonly Stopwatch _stopwatch;
        LoggerManager _loggerManager;

        public PerformanceAspect()
        {
            _stopwatch = new Stopwatch();
            _loggerManager = new LoggerManager();
        }

        public override void OnBefore(IInvocation invocation)
        {
            try
            {
                _stopwatch.Start();
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                // Handle specific exceptions here
                _loggerManager.LogError($"Error in {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}: {ex.Message}");
            }
            finally
            {
                _stopwatch.Stop();
                _loggerManager.LogInfo($"Performance ------------------------------------------: {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} took {_stopwatch.Elapsed.TotalSeconds} seconds");
                _stopwatch.Reset();
             }
        }
    }
}


