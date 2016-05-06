using ChatApp.Contracts.Services;

namespace ChatApp.Server.Services
{
    class RegistrationService : IRegistrationService
    {
        private object threadLock = new object();

        public bool Register(string userName)
        {
            lock (threadLock)
            {
                var registred = ServerContext.RegistredUsers.Contains(userName);
                if (registred) return false;
                else
                {
                    ServerContext.RegistredUsers.Add(userName);
                    return true;
                }
            }
        }
    }
}
