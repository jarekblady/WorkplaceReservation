using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkplaceReservation.Models;
using WorkplaceReservation.Service.DTOs;
using WorkplaceReservation.Service.Services.EquipmentService;
using WorkplaceReservation.Service.Services.WorkplaceService;

namespace WorkplaceReservation.Controllers
{
    public class WorkplaceController : Controller
    {
        private readonly IWorkplaceService _workplaceService;
        private readonly IEquipmentService _equipmentService;
        private IValidator<WorkplaceViewModel> _validator;
        private IValidator<EquipmentForWorkplaceViewModel> _equipmentForWorkplaceValidator;
        public WorkplaceController(IWorkplaceService workplaceService, IEquipmentService equipmentService, IValidator<WorkplaceViewModel> validator, IValidator<EquipmentForWorkplaceViewModel> equipmentForWorkplaceValidator)
        {
            _workplaceService = workplaceService;
            _equipmentService = equipmentService;
            _validator = validator;
            _equipmentForWorkplaceValidator = equipmentForWorkplaceValidator;
        }
        public IActionResult Index()
        {
            var viewModel = new WorkplaceViewModel();
            viewModel.Workplaces = _workplaceService.GetAllWorkplace();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkplaceViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Create", model);
            }

            var dto = new WorkplaceDto()
            {
                Floor = model.Workplace.Floor,
                Room = model.Workplace.Room,
                Table = model.Workplace.Table,
            };
            _workplaceService.CreateWorkplace(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new WorkplaceViewModel();
            viewModel.Workplace = _workplaceService.GetByIdWorkplace(id);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(WorkplaceViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Edit", model);
            }

            var dto = new WorkplaceDto()
            {
                Id = model.Workplace.Id,
                Floor = model.Workplace.Floor,
                Room = model.Workplace.Room,
                Table = model.Workplace.Table,
            };
            _workplaceService.UpdateWorkplace(dto);

            return RedirectToAction("Index"); ;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _workplaceService.DeleteWorkplace(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var viewModel = new EquipmentForWorkplaceViewModel();
            viewModel.EquipmentForWorkplaces = _workplaceService.GetAllEquipmentForWorkplaceId(id);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddEquipment()
        {
            var equipments = new EquipmentViewModel();
            equipments.Equipments = _equipmentService.GetAllEquipment();
            var workplaces = new WorkplaceViewModel();
            workplaces.Workplaces = _workplaceService.GetAllWorkplace();
            ViewBag.Equipments = new SelectList(equipments.Equipments, "Id", "Type");
            ViewBag.Workplaces = new SelectList(workplaces.Workplaces, "Id", "WorkplaceName");

            return View();
        }

        [HttpPost]
        public IActionResult AddEquipment(EquipmentForWorkplaceViewModel model)
        {
            var equipments = new EquipmentViewModel();
            equipments.Equipments = _equipmentService.GetAllEquipment();
            var workplaces = new WorkplaceViewModel();
            workplaces.Workplaces = _workplaceService.GetAllWorkplace();
            ViewBag.Equipments = new SelectList(equipments.Equipments, "Id", "Type");
            ViewBag.Workplaces = new SelectList(workplaces.Workplaces, "Id", "WorkplaceName");

            ValidationResult result = _equipmentForWorkplaceValidator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("AddEquipment", model);
            }

            var dto = new EquipmentForWorkplaceDto()
            {
                Count = model.EquipmentForWorkplace.Count,
                WorkplaceId = model.EquipmentForWorkplace.WorkplaceId,
                EquipmentId = model.EquipmentForWorkplace.EquipmentId,
            };
            _workplaceService.AddEquipmentForWorkplace(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditEquipment(int id)
        {
            var equipments = new EquipmentViewModel();
            equipments.Equipments = _equipmentService.GetAllEquipment();
            var workplaces = new WorkplaceViewModel();
            workplaces.Workplaces = _workplaceService.GetAllWorkplace();
            ViewBag.Equipments = new SelectList(equipments.Equipments, "Id", "Type");
            ViewBag.Workplaces = new SelectList(workplaces.Workplaces, "Id", "WorkplaceName");

            var viewModel = new EquipmentForWorkplaceViewModel();
            viewModel.EquipmentForWorkplace = _workplaceService.GetByIdEquipmentForWorkplace(id);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EditEquipment(EquipmentForWorkplaceViewModel model)
        {
            ValidationResult result = _equipmentForWorkplaceValidator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("EditEquipment", model);
            }

            var dto = new EquipmentForWorkplaceDto()
            {
                Id = model.EquipmentForWorkplace.Id,
                Count = model.EquipmentForWorkplace.Count,
                WorkplaceId = model.EquipmentForWorkplace.WorkplaceId,
                EquipmentId = model.EquipmentForWorkplace.EquipmentId,
            };
            _workplaceService.UpdateEquipmentForWorkplace(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEquipment(int id)
        {
            _workplaceService.DeleteEquipmentForWorkplace(id);
            return RedirectToAction("Index");
        }
    }
}
