using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WorkplaceDbContext _context;

        public EmployeeRepository(WorkplaceDbContext context)
        {
            _context = context;
        }

        public List<Employee> EmployeeGetAll()
        {

            return _context.Employees.Include(r => r.Reservations).ToList();
        }

        public Employee EmployeeGetById(int id)
        {
            return _context.Employees.Include(r => r.Reservations).FirstOrDefault(e => e.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {

            _context.Employees.Add(employee);
            _context.SaveChanges();

        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();

        }
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);

            _context.SaveChanges();

        }
    }
}