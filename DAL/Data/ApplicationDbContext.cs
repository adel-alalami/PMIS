using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
     
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
        public DbSet<Client> Clients { get; set; }
        //[NotMapped]
        //public DbSet<AjaxInvoiceDTO> invoiceDTOs { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<InvoicePaymentTerm>().HasKey(x => new { x.InvoiceId, x.PaymentTermId });

            builder.Entity<Project>().Property(x => x.StartDate).HasColumnType("date");
            //builder.Entity<Client>().HasNoKey();
        }

       
    }
}
