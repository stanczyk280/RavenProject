using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class EmployeeRepo : BaseRepo
    {
        public List<Employee> GetEmployees()
        {
            var employees = Session
                .Query<Employee>()
                .ToList();
            return employees;
        }

        public Employee GetEmployee(string id)
        {
            var employee = Session.Load<Employee>(id);
            return employee;
        }

        public void CreateEmployee(Employee newEmployee)
        {
            Session.Store(newEmployee);
            Session.SaveChanges();
        }

        public void UpdateEmployee(string id, Employee newEmployee)
        {
            var employee = Session.Load<Employee>(id);
            employee.Name = newEmployee.Name;
            employee.LastName = newEmployee.LastName;
            employee.BirthDate = newEmployee.BirthDate;
            employee.Country = newEmployee.Country;
            employee.City = newEmployee.City;
            employee.Street = newEmployee.Street;
            employee.PostalCode = newEmployee.PostalCode;
            employee.Email = newEmployee.Email;
            employee.PhoneNumber = newEmployee.PhoneNumber;
            employee.AccessLevel = newEmployee.AccessLevel;
            Session.SaveChanges();
        }

        public void DeleteEmployee(string id)
        {
            var employee = Session.Load<Employee>(id);
            if (employee == null)
            {
                Console.WriteLine("not found");
                return;
            }
            Session.Delete(employee);
            Session.SaveChanges();
        }
    }
}