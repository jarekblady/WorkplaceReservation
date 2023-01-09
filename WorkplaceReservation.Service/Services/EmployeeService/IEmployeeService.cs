using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployee();
        EmployeeDto GetByIdEmployee(int id);
        void CreateEmployee(EmployeeDto dto);
        void UpdateEmployee(EmployeeDto dto);
        void DeleteEmployee(int id);
    }
}
