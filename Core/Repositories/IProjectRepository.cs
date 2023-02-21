using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IProjectRepository
    {
        public List<Project> GetAllProjects();
        public List<Project> GetProjectManagerProjects(string projectManagerID);
        public int InsertProject(Project project);
        public Project GetById(int projectId);
        public void UpdateProject(Project project);
        public void RemoveProject(int project);
        public FileStreamResult ViewContract(int projectId);
    }
}
