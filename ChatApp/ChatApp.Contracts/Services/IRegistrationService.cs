using NFX.Glue;
using System;

namespace ChatApp.Contracts.Services
{
    [Glued]
    public interface IRegistrationService
    {
        bool Register(string userName);
    }
}
