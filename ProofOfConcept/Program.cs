using Castle.Windsor;
using Castle.Windsor.Installer;
using Polly;
using ProofOfConcept.Components.Interfaces;
using Service.Metadata.Interfaces;
using System;

namespace ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = SetupContainer();
            
            var testComponent = container.Resolve<ITestComponent>();

            testComponent.DoSomething();
            testComponent.AddNumbers(1, 2);
            testComponent.DoSomethingHierarchy();

            var client = container.Resolve<IAccountService>();

            
            var policy = Policy.Handle<InvalidOperationException>().WaitAndRetry(new[]
            {
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(2)
            });

            policy.Execute(() => client.DoWork());

            

            Console.Read();
        }

        private static WindsorContainer SetupContainer()
        {
            var container = new WindsorContainer();
            container.Install(
                FromAssembly.This()
                //new LoggerInstaller(),
                //new ErrorHandlingInstaller(),
                //new TestComponentInstaller()
                );

            return container;
        }
    }
}
