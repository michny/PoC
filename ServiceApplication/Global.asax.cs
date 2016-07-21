using BusinessLogic.Managers;
using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using ServiceApplication.Infrastructure.Installers;
using ServiceApplication.Installers;
using System;
using System.Web;
using System.Web.Routing;

namespace ServiceApplication
{
    public class Global : HttpApplication
    {
        IWindsorContainer _container;

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new WindsorContainer();
            container.Install(
                new LoggingInstaller(),
                new WcfInstaller(),
                new AccountInstaller()
                );

            _container = container;

            var manager = new AccountManager();
            manager.Stuff();

            //RouteTable.Routes.Add("AccountService", new WindsorServiceHostFactory<DefaultServiceModel>(container.Kernel));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}