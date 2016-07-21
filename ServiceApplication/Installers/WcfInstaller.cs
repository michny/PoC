using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using System.Linq;

namespace ServiceApplication.Installers
{
    public class WcfInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>();

            //container.Register(
            //    Types.FromThisAssembly().Pick().If(x => x.IsSubclassOf(typeof(ServiceBase))).Configure(
            //        configurer => configurer.
            //                        AsWcfService(DefaultServiceModel)).LifestylePerWebRequest;
        }
    }
}