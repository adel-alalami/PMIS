using Microsoft.AspNetCore.Http;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class EditProjectDTO 
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Range(1, 2, ErrorMessage = "Required")]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Project Type")]
        public int ProjectTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Project Status")]
        [Range(1, 3, ErrorMessage = "Required")]
        public int ProjectStatusId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Contract Amount")]
        [Range(100, int.MaxValue, ErrorMessage = "Amount must be no less than 100$")]
        public decimal ContractAmount { get; set; }

        [Required(ErrorMessage = "Required")]
        public int ClientId { get; set; }



        public Project ToProject(string projectManagerID)
        {
            var project = new Project();
            project.ProjectId = this.ProjectId;
            project.ProjectName = this.ProjectName;
            project.ProjectTypeId = this.ProjectTypeId;
            project.ProjectStatusId = this.ProjectStatusId;
            project.StartDate = this.StartDate;
            project.EndDate = this.EndDate;
            project.ContractAmount = this.ContractAmount;
            project.ProjectManagerId = projectManagerID;
            project.ClientId = this.ClientId;
            return project;
        }

        public KeyValuePair<bool, string[]> ValidateProjectDate()
        {
            bool isValid = true;
            string[] errorList = new string[2];
            if (this.StartDate.Date == new DateTime(0001, 1, 1))
            {
                errorList[0] = "Required";
                isValid = false;
            }

            if (this.EndDate.Date == new DateTime(0001, 1, 1) || this.StartDate >= this.EndDate)
            {
                errorList[1] = "End date is Required and must be no earlier than Start date.";
                isValid = false;
            }
            return new KeyValuePair<bool, string[]>(isValid, errorList);
        }
    }
}
