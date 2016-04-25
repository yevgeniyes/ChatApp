using NFX.Glue;
using System;

namespace ChatApp.Contracts.Services
{
    [Glued]
    public interface IChatService
    {
        bool PutMessage(Guid token, string message);
    }
}
