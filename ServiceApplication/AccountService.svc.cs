using BusinessLogic.Interfaces;
using Castle.Core.Logging;
using Service.Metadata.Interfaces;

namespace ServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : ServiceBase, IAccountService
    {
        private readonly IAccountManager _manager;

        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public AccountService(IAccountManager manager)
        {
            _manager = manager;
        }

        public void DoWork()
        {
            Logger.Info("Work done!");
            throw new System.InvalidOperationException("My error");
        }
    }
}
