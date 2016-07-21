using BusinessLogic.Interfaces;
using BusinessLogic.Managers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Service.Metadata.Interfaces;

namespace ServiceApplication.Installers
{
    public class AccountInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IAccountManager>().ImplementedBy<AccountManager>(),
                Component.For<IAccountService>().ImplementedBy<AccountService>().Named("AccountService")
                );
        }
    }
}