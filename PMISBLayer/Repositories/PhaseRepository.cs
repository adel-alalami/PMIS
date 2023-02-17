using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly ApplicationDbContext dbContext;
        public PhaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Phase> GetAllPhases()
        {
            return dbContext.Phases.ToList();
        }
    }
}
