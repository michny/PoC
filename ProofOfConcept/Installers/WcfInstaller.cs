using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;

namespace ProofOfConcept.Installers
{
    public class WcfInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>();

            container.Register(Types.FromAssemblyNamed("Service.Metadata").Pick().
                Configure(c => 
                            c.Named(c.Implementation.Name).
                            AsWcfClient(new DefaultClientModel
                            {
                                //Endpoint = Endpoint,
                            })));
        }
    }
}
