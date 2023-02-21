using DAL.Data;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Repositories;

namespace DAL.Repositories
{
    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProjectTypeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ProjectType> GetAllTypes()
        {
            return dbContext.ProjectTypes.ToList();
        }
    }
}
