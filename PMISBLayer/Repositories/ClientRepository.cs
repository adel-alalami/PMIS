using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        ApplicationDbContext dbContext;
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
