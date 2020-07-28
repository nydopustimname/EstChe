using Common.Entities;
using System;

namespace DALL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(UserProfile profile);
    }
}