using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class PaymentTermDTO
    {
        public int PaymentTermId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Payment TermTitle")]
        public string PaymentTermTitle { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Payment TermAmount")]
        public decimal PaymentTermAmount { get; set; }
        public int DeliverableId { get; set; }

        public PaymentTerm ToPaymentTerm()
        {
            var paymentTerm = new PaymentTerm();
            if (this.DeliverableId != 0)
                paymentTerm.DeliverableId = this.DeliverableId;
            paymentTerm.PaymentTermId = this.PaymentTermId;
            paymentTerm.PaymentTermAmount = this.PaymentTermAmount;
            paymentTerm.PaymentTermTitle = this.PaymentTermTitle;
            return paymentTerm;
        }

        public KeyValuePair<bool, string> CheckAmountTotal(Project project)
        {
            if(this.PaymentTermAmount == 0)
                return new KeyValuePair<bool, string>(false, "In Valid, must be greater than 0.");

            else if (project.ContractAmount < project.PaymentTermsTotal + this.PaymentTermAmount)
                return new KeyValuePair<bool, string>(false, $"In Valid, Payment Term Total must not exceed Projects contract amount.\n{project.ContractAmount - project.PaymentTermsTotal} left");

            else
                return new KeyValuePair<bool, string>(true, null);
        }
    }
}
