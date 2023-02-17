using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProjectRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Project> GetAllProjects()
        {
            return dbContext.Projects.Include(x => x.ProjectType).Include(x => x.ProjectStatus).Include(x => x.ProjectPhases).ToList();
        }

        public Project GetById(int projectId)
        {
            return dbContext.Projects
                .Include(x => x.ProjectType)
                .Include(x => x.ProjectStatus)
                .Include(x => x.ProjectPhases)
                .SingleOrDefault(x => x.ProjectId == projectId);
        }

        public List<Project> GetProjectManagerProjects(string projectManagerID)
        {
           // var persent = dbContext.Projects.ToList().Count().ToString("P");
            return dbContext.Projects.Where(x => x.ProjectManagerId == projectManagerID).Include(x => x.ProjectType).Include(x => x.ProjectStatus).ToList();
        }

        public int InsertProject(Project project)
        {
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return project.ProjectId;
        }

        public void RemoveProject(int projectId)
        {
            var project = GetById(projectId);
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
        }

        public void UpdateProject(Project newProject)
        {
            var currentProject = dbContext.Projects.SingleOrDefault(x => x.ProjectId == newProject.ProjectId);
            currentProject.ProjectName = newProject.ProjectName;
            currentProject.ProjectTypeId = newProject.ProjectTypeId;
            currentProject.ProjectStatusId = newProject.ProjectStatusId;
            currentProject.StartDate = newProject.StartDate;
            currentProject.EndDate = newProject.EndDate;
            currentProject.ContractAmount = newProject.ContractAmount;
            dbContext.SaveChanges();
        }


        public FileStreamResult ViewContract(int projectId)
        {
            var project = GetById(projectId);
            Stream stream = new MemoryStream(project.ContractFile);
            return new FileStreamResult(stream, project.ContractFileType);
        }
    }
}
