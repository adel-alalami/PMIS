
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class ProjectPhase 
    {
        public int ProjectPhaseId { get; set; }
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
