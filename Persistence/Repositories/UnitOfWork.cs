﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
       
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }

        public UnitOfWork(ApplicationDbContext db)
       {
           _db = db;
           UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
       }

        public  Task CommitAsync()
        {
            return _db.SaveChangesAsync();
        }

        public ValueTask RollBackAsync()
        {
            return _db.DisposeAsync();
        }
   }
}
