
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProjectPhaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ProjectPhase GetById(int projectPhaseId)
        {
            return dbContext.ProjectPhases
                .Include(x => x.Phase)
                .Include(x => x.Project).ToList()
                .SingleOrDefault(x => x.ProjectPhaseId == projectPhaseId);
                
        }

        public List<ProjectPhase> GetProjectPhases(int projectId)
        {
            return dbContext.ProjectPhases
                .Where(x => x.ProjectId == projectId)
                .Include(x => x.Phase)
                .Include(x => x.Project).ToList();
        }
        public void InsertProjectPhase(ProjectPhase projectPhase)
        {
            dbContext.ProjectPhases.Add(projectPhase);
            dbContext.SaveChanges();
        }

        public void RemoveProjectPhase(int projectPhaseId)
        {
            var projectPhase = GetById(projectPhaseId);
            if(projectPhase != null)
            {
                dbContext.ProjectPhases.Remove(projectPhase);
                dbContext.SaveChanges();
            }
        }

        public void UpdateProjectPhase(ProjectPhase projectPhase)
        {
            var currentProjectPhase = GetById(projectPhase.ProjectPhaseId);
            currentProjectPhase.PhaseId = projectPhase.PhaseId;
            currentProjectPhase.StartDate = projectPhase.StartDate;
            currentProjectPhase.EndDate = projectPhase.EndDate;
            dbContext.SaveChanges();
        }
        
    }
}
