﻿using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
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