using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IProjectStatusRepository
    {
        public List<ProjectStatus> GetAllStatuses();
    }
}
