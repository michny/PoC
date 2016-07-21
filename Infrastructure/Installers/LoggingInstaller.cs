using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.IO;
using Castle.Facilities.Logging;

namespace ServiceApplication.Infrastructure.Installers
{
    public class LoggingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
        }
    }
}