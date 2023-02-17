using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.Entities
{
    public class PaymentTerm
    {
        public int PaymentTermId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Payment TermTitle")]
        public string PaymentTermTitle { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Payment TermAmount")]
        public decimal PaymentTermAmount { get; set; }
        public int DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
        public List<InvoicePaymentTerm> invoicePaymentTerms { get; set; }

    }
}
