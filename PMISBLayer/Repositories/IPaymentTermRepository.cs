using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IPaymentTermRepository
    {
        public List<PaymentTerm> GetPaymentTerms(int deliverable);
        public List<PaymentTerm> GetPaymentTerms();
        public PaymentTerm GetById(int paymentTermId);
        public void InsertPaymentTerm(PaymentTerm paymentTerm, int projectId);
        public void RemovePaymentTerm(int paymentTermId);
        public void UpdatePaymentTerm(PaymentTerm paymentTerm);
        public List<AvPaymentTermDTO> GetAvailablePaymentTerm(int projectId);
        public List<AvPaymentTermDTO> GetAvailablePaymentTerm();
    }
}
