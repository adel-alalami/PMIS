using DAL.Data;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Repositories;


namespace DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Client> GetAllClients()
        {
            return dbContext.Clients.ToList();
        }
    }
}
