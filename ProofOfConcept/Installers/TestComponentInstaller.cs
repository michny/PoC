using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProofOfConcept.Components;
using ProofOfConcept.Components.Interfaces;

namespace ProofOfConcept.Installers
{
    public class TestComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITestComponent>().ImplementedBy<TestComponent>()); //.Interceptors(InterceptorReference.ForKey("LogInterceptor")).Anywhere
        }
    }
}
