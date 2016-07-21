using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.DynamicProxy;
using ProofOfConcept.Interceptors;

namespace ProofOfConcept.Installers
{
    public class ErrorHandlingInstaller : IWindsorInstaller
    {        
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IInterceptor>().ImplementedBy<ErrorInterceptor>().Named("ErrorInterceptor").IsDefault());
        }
    }
}
