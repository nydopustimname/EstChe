using Common.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(UserProfile profile);
    }
}