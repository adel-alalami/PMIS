using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }
        [Column(TypeName = "Date")]
        public DateTime InvoiceDate { get; set; }
        public List<InvoicePaymentTerm> invoicePaymentTerms { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
