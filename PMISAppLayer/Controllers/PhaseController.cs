using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class PhaseController : Controller
    {
        private readonly IProjectPhaseRepository ProjectPhaseRepository;
        private readonly IPhaseRepository PhaseRepository;
        private readonly IProjectRepository projectRepository;

        public PhaseController(
            IProjectRepository projectRepository,
            IProjectPhaseRepository ProjectPhaseRepository,
            IPhaseRepository PhaseRepository
            )
        {
            this.projectRepository = projectRepository;
            this.ProjectPhaseRepository = ProjectPhaseRepository;
            this.PhaseRepository = PhaseRepository;
        }
        public IActionResult Index(int projectId)
        {
            ViewBag.Phases = ProjectPhaseRepository.GetProjectPhases(projectId);
            ViewBag.ProjectId = projectId;
            ViewBag.Project = projectRepository.GetById(projectId);
            return View();
        }
        public IActionResult CreateNewPhase(int projectId)
        {
            ViewBag.ProjectId = projectId;
            ViewBag.Phases = PhaseRepository.GetAllPhases();
            ViewBag.Project = projectRepository.GetById(projectId);
            return View();
        }

        public IActionResult InsertNewPhase(int projectId, ProjectPhaseDTO projectPhaseDTO)
        {
            var project = projectRepository.GetById(projectId);
            var validateDate = projectPhaseDTO.ValidateProjecPhasetDate(project);
            if (!ModelState.IsValid || validateDate.Key == false)
            {
                ViewBag.DateErrors = validateDate.Value;
                ViewBag.ProjectId = projectId;
                ViewBag.Phases = PhaseRepository.GetAllPhases();
                return View("CreateNewPhase", projectPhaseDTO);
            }
            else
            {
                projectPhaseDTO.ProjectId = projectId;
                ProjectPhaseRepository.InsertProjectPhase(projectPhaseDTO.ToProjectPhase());
                return RedirectToAction("Index", new { ProjectId = projectId });
            }
        }
        public IActionResult EditProjectPhase(int projectPhaseId)
        {
            ViewBag.Phases = PhaseRepository.GetAllPhases();
            var ProjectPhase = ProjectPhaseRepository.GetById(projectPhaseId);
            ViewBag.ProjectId = ProjectPhase.ProjectId;
            return View(ProjectPhase);
        }
        public IActionResult UpdateProjectPhase( int projectPhaseId, int projectId, ProjectPhaseDTO projectPhaseDTO)
        {
            var project = projectRepository.GetById(projectId);
            var validateDate = projectPhaseDTO.ValidateProjecPhasetDate(project);
            if (!ModelState.IsValid || validateDate.Key == false)
            {
                ViewBag.DateErrors = validateDate.Value;
                ViewBag.ProjectId = projectId;
                ViewBag.Phases = PhaseRepository.GetAllPhases();
                return View("EditProjectPhase", projectPhaseDTO.ToProjectPhase());
            }
            else
            {
                projectPhaseDTO.ProjectPhaseId = projectPhaseId;
                ProjectPhaseRepository.UpdateProjectPhase(projectPhaseDTO.ToProjectPhase());
                return RedirectToAction("Index", new { ProjectId = projectId });
            }
        }
        public IActionResult RemoveProjectPhase(int projectPhaseId, int projectId)
        {
            ProjectPhaseRepository.RemoveProjectPhase(projectPhaseId);
            return RedirectToAction("Index", new { ProjectId = projectId });
        }
    }
}
