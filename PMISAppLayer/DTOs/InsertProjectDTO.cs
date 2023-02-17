using Microsoft.AspNetCore.Http;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace PMISAppLayer.DTOs
{
    public class InsertProjectDTO
    {
        [Required(ErrorMessage = "Required")]
        public string ProjectName { get; set; }

        [Range(1, 2, ErrorMessage= "Required")]
        [Required]
        public int ProjectTypeId { get; set; }
        

        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Range(1, 3, ErrorMessage = "Required")]
        [Required]
        public int ProjectStatusId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(100,int.MaxValue, ErrorMessage ="Amount must be no less than 100$")]
        public decimal ContractAmount { get; set; }

        [Required(ErrorMessage = "Required")]
        public IFormFile ContractFile { get; set; }

        [Range(1,1000, ErrorMessage = "Required")]
        [Required(ErrorMessage = "Required")]
        public int ClientId { get; set; }

        public Project ToProject(string projectManagerID)
        {
            var project = new Project();
            project.ProjectName = this.ProjectName;
            project.ProjectTypeId = this.ProjectTypeId;
            project.ProjectStatusId = this.ProjectStatusId;
            project.StartDate = this.StartDate;
            project.EndDate = this.EndDate;
            project.ContractAmount = this.ContractAmount;
            project.ContractFileName = this.ContractFile.FileName;
            project.ContractFileType = this.ContractFile.ContentType;
            project.ProjectManagerId = projectManagerID;
            project.ClientId = this.ClientId;

            if (this.ContractFile.Length > 0)
            {
                Stream st = this.ContractFile.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    var byteFile = br.ReadBytes((int)st.Length);
                    project.ContractFile = byteFile;
                }
            }
            return project;
        }

        public KeyValuePair<bool, string[]> ValidateProjectDate()
        {
            bool isValid = true;
            string[] errorList = new string[2];
            if (this.StartDate.Date == new DateTime(0001, 1, 1) || this.StartDate < DateTime.Now.Date)
            {
                errorList[0] = "start date is Required and must be no earlier than today";
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
