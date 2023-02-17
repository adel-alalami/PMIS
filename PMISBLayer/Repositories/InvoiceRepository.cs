using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        ApplicationDbContext dbContext;
        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Invoice> GetAllInvoices(string projectManagerId)
        {
            return dbContext.Invoices.Include(x => x.Project).Where(x => x.Project.ProjectManagerId == projectManagerId).ToList();
        }
        public List<Invoice> GetAllInvoices()
        {
            return dbContext.Invoices.Include(x => x.Project).Include(x => x.invoicePaymentTerms).ThenInclude(x => x.PaymentTerm).ToList();
        }

        public void InsertInvoide(Invoice invoice)
        {
            dbContext.Invoices.Add(invoice);
            dbContext.SaveChanges();

            foreach (var paymentTerm in invoice.invoicePaymentTerms)
            {
                dbContext.InvoicePaymentTerms.Add(paymentTerm);
            }
        }
        public Invoice GetById(int invoiceId)
        {
            return dbContext.Invoices.Include(x => x.Project).ThenInclude(p => p.Client).Include(x => x.invoicePaymentTerms)
                .ThenInclude(x => x.PaymentTerm).ThenInclude(x => x.Deliverable)
                .SingleOrDefault(x => x.InvoiceId == invoiceId);
        }

    }
}
