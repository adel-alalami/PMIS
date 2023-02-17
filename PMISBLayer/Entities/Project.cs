using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal PaymentTermsTotal { get; set; }
        public string ContractFileName { get; set; }
        public string ContractFileType { get; set; }
        public byte[] ContractFile { get; set; }
        public string ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Invoice> Invoices { get; set; }

    }
}
