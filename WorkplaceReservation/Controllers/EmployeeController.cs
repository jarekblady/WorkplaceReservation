using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WorkplaceReservation.Models;
using WorkplaceReservation.Service.DTOs;
using WorkplaceReservation.Service.Services.EmployeeService;

namespace WorkplaceReservation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private IValidator<EmployeeViewModel> _validator;
        public EmployeeController(IEmployeeService employeeService, IValidator<EmployeeViewModel> validator)
        {
            _employeeService = employeeService;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var viewModel = new EmployeeViewModel();
            viewModel.Employees = _employeeService.GetAllEmployee();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Create", model);
            }
            var dto = new EmployeeDto()
            {
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName,
            };

            _employeeService.CreateEmployee(dto);

            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new EmployeeViewModel();
            viewModel.Employee = _employeeService.GetByIdEmployee(id);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Edit", model);
            }

            var dto = new EmployeeDto()
            {
                Id = model.Employee.Id,
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName,
            };
            _employeeService.UpdateEmployee(dto);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}