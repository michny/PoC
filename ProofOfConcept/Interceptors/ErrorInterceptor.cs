using Castle.Core.Logging;
using Castle.DynamicProxy;
using System;

namespace ProofOfConcept.Interceptors
{
    public class ErrorInterceptor : IInterceptor
    {
        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Logger.Error("ERROR", ex);
                //Console.WriteLine($"Error: {ex}");
            }
            
        }
    }
}
