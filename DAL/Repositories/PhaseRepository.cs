using DAL.Data;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Repositories;


namespace DAL.Repositories
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
