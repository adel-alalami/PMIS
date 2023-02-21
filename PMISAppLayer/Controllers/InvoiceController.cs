using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository InvoiceRepository;
        private readonly IProjectRepository ProjectRepository;
        private readonly IPaymentTermRepository PaymentTermRepository;
        public InvoiceController(IInvoiceRepository InvoiceRepository, IProjectRepository ProjectRepository, IPaymentTermRepository PaymentTermRepository)
        {
            this.InvoiceRepository = InvoiceRepository;
            this.ProjectRepository = ProjectRepository;
            this.PaymentTermRepository = PaymentTermRepository;
        }
        public JsonResult GetProjectPaymentTerm(int projectId)
        {
            var paymentTerms = PaymentTermRepository.GetAvailablePaymentTerm(projectId);
            return new JsonResult(paymentTerms);
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.invoices = InvoiceRepository.GetAllInvoices();
                return View();
            }
            else
            {
                ViewBag.invoices = InvoiceRepository.GetAllInvoices(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View();
            }
            
        }
        [Authorize(Roles = "ProjectManager")]
        public IActionResult CreateNewInvoice()
        {
            ViewBag.Projects = ProjectRepository.GetProjectManagerProjects(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }
        [Authorize(Roles = "ProjectManager")]
        public IActionResult InsertInvoice(InvoiceDTO invoiceDTO)
        {
            if (ModelState.IsValid)
            {
                InvoiceRepository.InsertInvoide(invoiceDTO.ToInvoice());
                return RedirectToAction("Index");
            }
            return View("CreateNewInvoice", invoiceDTO);
        }

        public IActionResult EditInvoice(int invoiceId)
        {
            //ViewBag.Projects = ProjectRepository.GetProjectManagerProjects(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var invoice = InvoiceRepository.GetById(invoiceId);
            ViewBag.PaymentTerm = PaymentTermRepository.GetAvailablePaymentTerm(invoice.ProjectId);
            return View(invoice);
        }

        public IActionResult UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            return View();
        }
        public IActionResult ViewInvoice(int invoiceId)
        {
            var Invoice = InvoiceRepository.GetById(invoiceId);
            return View(Invoice);
        }
    }
}
