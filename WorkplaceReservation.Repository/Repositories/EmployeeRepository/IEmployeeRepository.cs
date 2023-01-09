using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> EmployeeGetAll();
        Employee EmployeeGetById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}