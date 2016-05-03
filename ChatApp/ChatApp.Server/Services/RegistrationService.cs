using ChatApp.Contracts.Services;

namespace ChatApp.Server.Services
{
    class RegistrationService : IRegistrationService
    {
        public bool Register(string userName)
        {
            for (int i = 0; i < ServerContext._registredUsers.Count; i++)
            {
                var registredUser = ServerContext._registredUsers[i];
                if (userName == registredUser)
                {
                    return false;
                }
            }
            ServerContext._registredUsers.Add(userName);
            return true;
        }
    }
}
