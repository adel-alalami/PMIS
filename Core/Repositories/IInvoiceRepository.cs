using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IInvoiceRepository
    {
        public List<Invoice> GetAllInvoices(string projectManagerId);
        public List<Invoice> GetAllInvoices();
        public void InsertInvoide(Invoice invoice);
        public Invoice GetById(int invoiceId);
    }
}
