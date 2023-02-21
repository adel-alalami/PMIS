using Microsoft.AspNetCore.Mvc;
using System;
using Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Core.Entities;


namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;
        private readonly IProjectTypeRepository projectTypeRepository;
        private readonly IProjectStatusRepository projectStatusRepository;
        private readonly IProjectPhaseRepository projectPhaseRepository;
        
        public ProjectController(
            IProjectRepository projectRepository,
            IProjectTypeRepository projectTypeRepository,
            IProjectStatusRepository projectStatusRepository,
            IProjectPhaseRepository projectPhaseRepository,
            IClientRepository clientRepository
            )
        {
            this.projectRepository = projectRepository;
            this.projectTypeRepository = projectTypeRepository;
            this.projectStatusRepository = projectStatusRepository;
            this.projectPhaseRepository = projectPhaseRepository;
            this.clientRepository = clientRepository;
        }
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            if (User.IsInRole("Admin"))
            {
                ViewBag.Projects = projectRepository.GetAllProjects();
                return View();
            }
            else
            {
                ViewBag.Projects = projectRepository.GetProjectManagerProjects(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View();
            }
        }
        public IActionResult CreateNewProject()
        {
            ViewBag.ProjectTypes = projectTypeRepository.GetAllTypes();
            ViewBag.ProjectStatuses = projectStatusRepository.GetAllStatuses();
            ViewBag.Clients = clientRepository.GetAllClients();
            return View();
        }
        [HttpPost]
        public IActionResult InsertNewProject(InsertProjectDTO insertProjectDTO)
        {
            var validateDate = insertProjectDTO.ValidateProjectDate();
            if (!ModelState.IsValid || validateDate.Key == false)
            {
                ViewBag.DateErrors = validateDate.Value;
                ViewBag.ProjectTypes = projectTypeRepository.GetAllTypes();
                ViewBag.ProjectStatuses = projectStatusRepository.GetAllStatuses();
                ViewBag.Clients = clientRepository.GetAllClients();
                return View("CreateNewProject", insertProjectDTO);
            }
            else
            {
                var projectManagerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                projectRepository.InsertProject(insertProjectDTO.ToProject(projectManagerID));
                return RedirectToAction("Index");
            }
        }
        public IActionResult EditProject(int projectId)
        {
            var Project = projectRepository.GetById(projectId);
            ViewBag.ProjectTypes = projectTypeRepository.GetAllTypes();
            ViewBag.ProjectStatuses = projectStatusRepository.GetAllStatuses();
            ViewBag.Clients = clientRepository.GetAllClients();
            return View(Project);
        }
        public IActionResult UpdateProject(EditProjectDTO editProjectDTO)
        {
            var validateDate = editProjectDTO.ValidateProjectDate();
            if (!ModelState.IsValid || validateDate.Key == false)
            {
                ViewBag.DateErrors = validateDate.Value;
                ViewBag.ProjectTypes = projectTypeRepository.GetAllTypes();
                ViewBag.ProjectStatuses = projectStatusRepository.GetAllStatuses();
                ViewBag.Clients = clientRepository.GetAllClients();
                return View("EditProject", editProjectDTO.ToProject(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            var projectManagerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            projectRepository.UpdateProject(editProjectDTO.ToProject(projectManagerID));
            return RedirectToAction("Index");
        }
        public IActionResult RemoveProject(int projectId)
        {
            projectRepository.RemoveProject(projectId);
            return RedirectToAction("Index");
        }
        public FileStreamResult ViewContract(int projectId)
        {
            return projectRepository.ViewContract(projectId);
        }

        
    }
}
