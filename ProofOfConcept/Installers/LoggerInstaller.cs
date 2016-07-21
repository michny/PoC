using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.DynamicProxy;
using System.IO;
using Castle.Facilities.Logging;
using ProofOfConcept.Interceptors;

namespace ProofOfConcept.Installers
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            container.Register(Component.For<IInterceptor>().ImplementedBy<LogInterceptor>().Named("LogInterceptor").IsDefault());
        }
    }
}
