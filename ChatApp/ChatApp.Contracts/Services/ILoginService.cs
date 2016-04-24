using NFX.Glue;
using System;

namespace ChatApp.Contracts.Services
{
    [Glued]
    public interface ILoginService
    {
        Guid Login(string name);
    }
}
