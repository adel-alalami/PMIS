using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
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
