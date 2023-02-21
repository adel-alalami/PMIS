
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ProjectPhaseDTO 
    {
        public int ProjectPhaseId { get; set; }
        public int ProjectId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Required")]
        public int PhaseId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public ProjectPhase ToProjectPhase()
        {
            var projectPhase = new ProjectPhase();
            if (this.ProjectPhaseId != 0)
                projectPhase.ProjectPhaseId = this.ProjectPhaseId;
            projectPhase.PhaseId = this.PhaseId;
            projectPhase.ProjectId = this.ProjectId;
            projectPhase.StartDate = this.StartDate;
            projectPhase.EndDate = this.EndDate;

            return projectPhase;
        }

        public KeyValuePair<bool, string[]> ValidateProjecPhasetDate(Project project)
        {
            bool isValid = true;
            string[] errorList = new string[3];
            if (this.StartDate.Date == new DateTime(0001, 1, 1) || this.StartDate < project.StartDate)
            {
                errorList[0] = "Phase start date is Required and must be no earlier than project start date";
                isValid = false;
            }

            if (this.EndDate.Date == new DateTime(0001, 1, 1) || this.EndDate > project.EndDate)
            {
                errorList[1] = " Phase end date is Required and must be no later than project end date.";
                isValid = false;
            }

            if (this.StartDate >= this.EndDate)
            {
                errorList[3] = "End date must be no earlier than Start date.";
                isValid = false;
            }
            return new KeyValuePair<bool, string[]>(isValid, errorList);
        }
    }
    
}
