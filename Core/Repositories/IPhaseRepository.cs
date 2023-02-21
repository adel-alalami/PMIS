using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IPhaseRepository
    {
        public List<Phase> GetAllPhases();
    }
}
