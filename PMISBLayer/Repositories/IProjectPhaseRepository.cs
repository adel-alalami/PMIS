using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectPhaseRepository
    {
        public List<ProjectPhase> GetProjectPhases(int projectId);
        public ProjectPhase GetById(int projectPhaseId);
        public void InsertProjectPhase(ProjectPhase projectPhase);
        public void RemoveProjectPhase(int projectPhaseId);
        public void UpdateProjectPhase(ProjectPhase projectPhase); 
    }
}
