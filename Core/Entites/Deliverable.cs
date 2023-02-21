
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Deliverable 
    {
        public int DeliverableId { get; set; }

        public string DeliverableName { get; set; }

        public string DeliverableDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int ProjectPhaseId { get; set; }
        public ProjectPhase ProjectPhase { get; set; }

    }
}
