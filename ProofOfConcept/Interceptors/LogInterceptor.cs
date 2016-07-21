using Castle.Core.Logging;
using Castle.DynamicProxy;
using ProofOfConcept.Attributes;
using System.Linq;

namespace ProofOfConcept.Interceptors
{
    class LogInterceptor : IInterceptor
    {
        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public void Intercept(IInvocation invocation)
        {
            //invocation.MethodInvocationTarget.IsDefined(typeof(LogAttribute), true)
            var logAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(true).OfType<LogAttribute>().FirstOrDefault();
            if (logAttribute != null && logAttribute.LogTypes.Contains(LogType.Input))
                if (Logger.IsDebugEnabled) Logger.Debug($"Method {invocation.Method} in {invocation.Method.DeclaringType} called with arguments {string.Join(",", invocation.Arguments)}");

            invocation.Proceed();

            if (logAttribute != null && logAttribute.LogTypes.Contains(LogType.Output))
                if (Logger.IsDebugEnabled) Logger.Debug($"Method {invocation.Method} returned {invocation.ReturnValue}");
        }
    }
}
