using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string InvoiceTitle { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public List<int> InvoicePaymentTerms { get; set; }

        [Required(ErrorMessage = "Required")]
        public int ProjectId { get; set; }

        public Invoice ToInvoice()
        {
            var invoice = new Invoice();
            invoice.InvoiceTitle = this.InvoiceTitle;
            invoice.InvoiceDate = this.InvoiceDate;
            invoice.ProjectId = this.ProjectId;
            invoice.invoicePaymentTerms = new List<InvoicePaymentTerm>();
            foreach (var paymentTerm in this.InvoicePaymentTerms)
            {
                invoice.invoicePaymentTerms.Add(new InvoicePaymentTerm { PaymentTermId = paymentTerm });
            }
            return invoice;
        }
    }
}
