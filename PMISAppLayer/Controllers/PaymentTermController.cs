using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISAppLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class PaymentTermController : Controller
    {
        IPaymentTermRepository paymentTermRepository;
        IDeliverableRepository deliverableRepository;
        public PaymentTermController(IPaymentTermRepository paymentTermRepository, IDeliverableRepository deliverableRepository)
        {
            this.paymentTermRepository = paymentTermRepository;
            this.deliverableRepository = deliverableRepository;
        }
        public IActionResult PaymentTermIndex(int deliverableId)
        {
            ViewBag.PaymentTerms = paymentTermRepository.GetPaymentTerms(deliverableId);
            ViewBag.DeliverableId = deliverableId;
            return View();
        }
        public IActionResult CreateNewpaymentTerm(int deliverableId)
        {
            ViewBag.deliverableId = deliverableId;
            ViewBag.Deliverable = deliverableRepository.GetById(deliverableId);

            return View();
        }
        public IActionResult InsertPaymentTerm([FromQuery(Name = "deliverableId")] int deliverableId, PaymentTermDTO paymentTermDTO)
        {
            var project = deliverableRepository.GetById(deliverableId).ProjectPhase.Project;
            var validateAmount = paymentTermDTO.CheckAmountTotal(project);
            
            if (ModelState.IsValid && validateAmount.Key == true)
            {
                paymentTermDTO.DeliverableId = deliverableId;
                paymentTermRepository.InsertPaymentTerm(paymentTermDTO.ToPaymentTerm(), project.ProjectId);
                return RedirectToAction("PaymentTermIndex", new { deliverableId = deliverableId }); 
            }
            else
            {
                ViewBag.Message = validateAmount.Value;
                ViewBag.deliverableId = deliverableId;
                return View("CreateNewpaymentTerm", paymentTermDTO);
            }
        }
        public IActionResult EditPaymentTerm(int paymentTermId)
        {
            var paymentTerm = paymentTermRepository.GetById(paymentTermId);
            ViewBag.deliverableId = paymentTerm.DeliverableId;
            return View(paymentTerm);
        }
        public IActionResult UpdatePaymentTerm(int paymentTermId, int deliverableId, PaymentTermDTO paymentTermDTO)
        {
            var project = deliverableRepository.GetById(deliverableId).ProjectPhase.Project;
            var validateAmount = paymentTermDTO.CheckAmountTotal(project);

            if (ModelState.IsValid && validateAmount.Key == true)
            {
                paymentTermDTO.PaymentTermId = paymentTermId;
                paymentTermRepository.UpdatePaymentTerm(paymentTermDTO.ToPaymentTerm());
                return RedirectToAction("PaymentTermIndex", new { deliverableId = deliverableId });
            }
            else
            {
                ViewBag.Message = validateAmount.Value;
                ViewBag.deliverableId = deliverableId;
                return View("CreateNewpaymentTerm", paymentTermDTO);
            }
        }
        public IActionResult RemovePaymentTerm(int paymentTermId, int deliverableId)
        {
            paymentTermRepository.RemovePaymentTerm(paymentTermId);
            return RedirectToAction("PaymentTermIndex", new { deliverableId = deliverableId });
        }

    }
}
