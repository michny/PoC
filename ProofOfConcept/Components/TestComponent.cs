using Castle.Core;
using ProofOfConcept.Components.Interfaces;
using ProofOfConcept.Attributes;
using Castle.Core.Logging;

namespace ProofOfConcept.Components
{
    [Interceptor("LogInterceptor")]
    [Interceptor("ErrorInterceptor")]
    public class TestComponent : ITestComponent
    {
        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        [Log(new[] { LogType.Input, LogType.Output })]
        public int AddNumbers(int a, int b)
        {
            Logger.Info("Adding Numbers");
            return a + b;
        }

        [Log(new[] { LogType.Input })]
        public void DoSomething()
        {
            Logger.Info("I did stuff");
            //throw new Exception("I DID SOME BAD STUFF");
        }

        [Log(new[] { LogType.Input, LogType.Output })]
        public void DoSomethingHierarchy()
        {
            Logger.Info("I did something before something else");
            DoSomething();
        }
    }
}
