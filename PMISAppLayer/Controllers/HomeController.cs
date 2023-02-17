using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMISBLayer.Models;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PMISBLayer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IProjectRepository projectRepository;
        IClientRepository clientRepository;
        IInvoiceRepository invoiceRepository;
        IPaymentTermRepository paymentTermRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController
            (
            IProjectRepository projectRepository,
            IClientRepository clientRepository,
            IInvoiceRepository invoiceRepository,
            IPaymentTermRepository paymentTermRepository,
            ILogger<HomeController> logger
            )
        {
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
            this.invoiceRepository = invoiceRepository;
            this.paymentTermRepository = paymentTermRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var projects = projectRepository.GetAllProjects();
            ViewBag.projectCount = projects.Count;
            ViewBag.pendingCount = projects.Where(x => x.ProjectStatus.ProjectStatusName == "Pending").ToList().Count;
            ViewBag.activeCount = projects.Where(x => x.ProjectStatus.ProjectStatusName == "InProgress").ToList().Count;
            ViewBag.completedCount = projects.Where(x => x.ProjectStatus.ProjectStatusName == "Completed").ToList().Count;
                
            var invoices = invoiceRepository.GetAllInvoices();
            ViewBag.invoiceCount = invoiceRepository.GetAllInvoices().Count;

            var paymentTerms = paymentTermRepository.GetPaymentTerms();
            ViewBag.totalAmount = paymentTerms.Sum(x => x.PaymentTermAmount);

            var avaPaymentTerms = paymentTermRepository.GetAvailablePaymentTerm();
            ViewBag.notPaiedAmount = avaPaymentTerms.Sum(x => x.PaymentTermAmount);

            ViewBag.paidAmount = paymentTerms.Sum(x => x.PaymentTermAmount) - avaPaymentTerms.Sum(x => x.PaymentTermAmount);

            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
