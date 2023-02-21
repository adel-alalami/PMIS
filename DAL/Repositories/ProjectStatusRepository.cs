using DAL.Data;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Repositories;


namespace DAL.Repositories
{
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProjectStatusRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ProjectStatus> GetAllStatuses()
        {
            return dbContext.ProjectStatuses.ToList();
        }
    }
}
