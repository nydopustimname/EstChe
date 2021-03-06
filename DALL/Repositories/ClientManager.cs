﻿using DALL.Context;
using Common.Entities;
using DALL.Interfaces;


namespace DALL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApContext DB { get; set; } 
        public ClientManager (ApContext db)
        {
            DB = db;
        }
        public void Create(UserProfile profile)
        {
            DB.UserProfiles.Add(profile);
            DB.SaveChanges();
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
