using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class DeliverableController : Controller
    {
        private readonly IDeliverableRepository deliverableRepository;
        private readonly IProjectPhaseRepository projectPhaseRepository;
        public DeliverableController(IDeliverableRepository deliverableRepository, IProjectPhaseRepository projectPhaseRepository)
        {
            this.deliverableRepository = deliverableRepository;
            this.projectPhaseRepository = projectPhaseRepository;
        }
        public IActionResult Index(int projectPhaseId)
        {
            ViewBag.Deliverables = deliverableRepository.GetDeliverables(projectPhaseId);
            ViewBag.ProjectPhaseId = projectPhaseId;
            ViewBag.ProjectPhase = projectPhaseRepository.GetById(projectPhaseId);
            return View();
        }
        public IActionResult CreateNewDeliverable(int projectPhaseId)
        {
            var projectPhase = projectPhaseRepository.GetById(projectPhaseId);
            ViewBag.ProjectPhaseId = projectPhaseId;
            ViewBag.ProjectPhase = projectPhaseRepository.GetById(projectPhaseId);
            return View();
        }
        public IActionResult InsertDeliverable(int projectPhaseId, DeliverableDTO deliverableDTO)
        {
            var projectPhase = projectPhaseRepository.GetById(projectPhaseId);
            var validateDate = deliverableDTO.ValidateDeliverabletDate(projectPhase);
            if (!ModelState.IsValid || validateDate.Key == false)
            {
                ViewBag.DateErrors = validateDate.Value;
                ViewBag.ProjectPhaseId = projectPhaseId;
                return View("CreateNewDeliverable", deliverableDTO);
            }
            else
            {
                deliverableDTO.ProjectPhaseId = projectPhaseId;
                deliverableRepository.InsertDeliverable(deliverableDTO.ToDeliverable());
                return RedirectToAction("Index", new { projectPhaseId = projectPhaseId }); 
            }
            
        }
        public IActionResult EditDeliverable(int deliverableId)
        {
            var Deliverable = deliverableRepository.GetById(deliverableId);
            ViewBag.projectPhaseId = Deliverable.ProjectPhaseId;
            return View(Deliverable);
        }
        public IActionResult UpdateDeliverable(int deliverableId, int projectPhaseId, DeliverableDTO deliverableDTO)
        {
            var projectPhase = projectPhaseRepository.GetById(projectPhaseId);
            var validateDate = deliverableDTO.ValidateDeliverabletDate(projectPhase);
            if (!ModelState.IsValid || validateDate.Key == false)
            {
                ViewBag.DateErrors = validateDate.Value;
                ViewBag.projectPhaseId = deliverableDTO.ProjectPhaseId;
                return View("EditDeliverable", deliverableDTO);
            }
            else
            {
                deliverableDTO.DeliverableId = deliverableId;
                deliverableRepository.UpdateDeliverable(deliverableDTO.ToDeliverable());
                return RedirectToAction("Index", new { projectPhaseId = projectPhaseId });
            }
            
        }
        public IActionResult RemoveDeliverable(int deliverableId, int projectPhaseId)
        {
            deliverableRepository.RemoveDeliverable(deliverableId);
            return RedirectToAction("Index", new { projectPhaseId = projectPhaseId });
        }
    }
}
