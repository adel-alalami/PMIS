using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class PaymentTermRepository : IPaymentTermRepository
    {
        private readonly ApplicationDbContext dbContext;
        public PaymentTermRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public PaymentTerm GetById(int paymentTermId)
        {
            return dbContext.PaymentTerms
                .Include(x => x.Deliverable)
                .Include(x => x.invoicePaymentTerms).ToList()
                .SingleOrDefault(x => x.PaymentTermId == paymentTermId);
        }

        public List<PaymentTerm> GetPaymentTerms(int deliverableId)
        {
            return dbContext.PaymentTerms
                .Where(x => x.DeliverableId == deliverableId)
                .Include(x => x.Deliverable)
                .Include(x => x.invoicePaymentTerms).ToList();
        }
        public List<PaymentTerm> GetPaymentTerms()
        {
            return dbContext.PaymentTerms
                .Include(x => x.Deliverable)
                .Include(x => x.invoicePaymentTerms).ToList();
        }
        public List<AvPaymentTermDTO> GetAvailablePaymentTerm(int projectId)
        {
            var avPaymentTerms = dbContext.PaymentTerms
            .Include(x => x.Deliverable).ThenInclude(p => p.ProjectPhase)
            .Include(x => x.invoicePaymentTerms)
            .Where(x => x.Deliverable.ProjectPhase.ProjectId == projectId && x.invoicePaymentTerms.Count == 0).ToList()
            .Select(x => new AvPaymentTermDTO
            {
                DeliverableName = x.Deliverable.DeliverableName,
                PaymentTermAmount = x.PaymentTermAmount,
                PaymentTermId = x.PaymentTermId,
                PaymentTermTitle = x.PaymentTermTitle
            }).ToList();
            return avPaymentTerms;
        }
        public List<AvPaymentTermDTO> GetAvailablePaymentTerm()
        {
            var avPaymentTerms = dbContext.PaymentTerms
            .Include(x => x.Deliverable).ThenInclude(p => p.ProjectPhase)
            .Include(x => x.invoicePaymentTerms)
            .Where(x => x.invoicePaymentTerms.Count == 0).ToList()
            .Select(x => new AvPaymentTermDTO
            {
                DeliverableName = x.Deliverable.DeliverableName,
                PaymentTermAmount = x.PaymentTermAmount,
                PaymentTermId = x.PaymentTermId,
                PaymentTermTitle = x.PaymentTermTitle
            }).ToList();
            return avPaymentTerms;
        }
        public void InsertPaymentTerm(PaymentTerm paymentTerm, int projectId)
        {
            dbContext.PaymentTerms.Add(paymentTerm);
            dbContext.Projects.SingleOrDefault(x => x.ProjectId == projectId).PaymentTermsTotal += paymentTerm.PaymentTermAmount;
            dbContext.SaveChanges();
        }

        public void RemovePaymentTerm(int paymentTermId)
        {
            var paymentTerm = GetById(paymentTermId);
            dbContext.PaymentTerms.Remove(paymentTerm);
            dbContext.SaveChanges();
        }

        public void UpdatePaymentTerm(PaymentTerm paymentTerm)
        {
            var currenrPaymentTerm = GetById(paymentTerm.PaymentTermId);
            currenrPaymentTerm.PaymentTermTitle = paymentTerm.PaymentTermTitle;
            currenrPaymentTerm.PaymentTermAmount = paymentTerm.PaymentTermAmount;
            dbContext.SaveChanges();
        }
    }
}
