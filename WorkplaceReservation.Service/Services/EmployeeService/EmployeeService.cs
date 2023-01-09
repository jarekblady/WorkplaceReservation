using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkplaceReservation.Repository.Entities;
using WorkplaceReservation.Repository.Repositories.EmployeeRepository;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public List<EmployeeDto> GetAllEmployee()
        {
            var employees = _employeeRepository.EmployeeGetAll();
            var result = _mapper.Map<List<EmployeeDto>>(employees);
            return result;
        }

        public EmployeeDto GetByIdEmployee(int id)
        {
            var employee = _employeeRepository.EmployeeGetById(id);
            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }


        public void CreateEmployee(EmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _employeeRepository.CreateEmployee(employee);
        }

        public void UpdateEmployee(EmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _employeeRepository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.EmployeeGetById(id);
            _employeeRepository.DeleteEmployee(employee);
        }


    }
}
