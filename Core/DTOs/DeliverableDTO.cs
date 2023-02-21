using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DeliverableDTO
    {
        public int DeliverableId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string DeliverableName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string DeliverableDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int ProjectPhaseId { get; set; }

        public Deliverable ToDeliverable()
        {
            var deliverable = new Deliverable();
            if (this.DeliverableId != 0)
                deliverable.DeliverableId = this.DeliverableId;
            deliverable.ProjectPhaseId = this.ProjectPhaseId;
            deliverable.DeliverableName = this.DeliverableName;
            deliverable.DeliverableDescription = this.DeliverableDescription;
            deliverable.StartDate = this.StartDate;
            deliverable.EndDate = this.EndDate;

            return deliverable;
        }

        public KeyValuePair<bool, string[]> ValidateDeliverabletDate(ProjectPhase projectPhase)
        {
            bool isValid = true;
            string[] errorList = new string[3];
            if (this.StartDate.Date == new DateTime(0001, 1, 1) || this.StartDate < projectPhase.StartDate)
            {
                errorList[0] = "deliverable start date is Required and must be no earlier than Phase start date";
                isValid = false;
            }

            if (this.EndDate.Date == new DateTime(0001, 1, 1) || this.EndDate > projectPhase.EndDate)
            {
                errorList[1] = "deliverable end date is Required and must be no later than Phase end date.";
                isValid = false;
            }

            if (this.StartDate >= this.EndDate)
            {
                errorList[2] = "End date must be no earlier than Start date.";
                isValid = false;
            }
            return new KeyValuePair<bool, string[]>(isValid, errorList);
        }


    }
    

}
