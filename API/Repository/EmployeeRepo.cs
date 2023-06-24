using Domain;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Common.Books_CategoryBookCount;
using static API.Common.MultiMapIndexes;

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

        public List<Employee> GetEmployeesWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 || pagesize > 0)
            {
                var employees = Session
                .Query<Employee>()
                .OrderBy(e => e.Name)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return employees.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning empty query");
                return null;
            }
        }

        public List<Employee> GetEmployeesByNameAndLastNameWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 && pagesize > 0)
            {
                var employees = Session
                .Query<Employee>()
                .OrderBy(e => e.Name)
                .ThenBy(e => e.LastName)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return employees.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning empty query");
                return null;
            }
        }

        public List<Employee> GetEmployeesByAccessLevelWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 || pagesize > 0)
            {
                var employees = Session
                .Query<Employee>()
                .OrderBy(e => e.AccessLevel)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return employees.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning empty query");
                return null;
            }
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

        public List<Employees_AccessLevelCount.Result> GetEmployeesAccessCount()
        {
            var results = Session
                .Query<Employees_AccessLevelCount.Result, Employees_AccessLevelCount>()
                .Include(e => e.AccessLevel)
                .ToList();
            return results;
        }

        public List<People_Search.Result> SearchPeople(string searchTerms)
        {
            var results = Session.Query<People_Search.Result, People_Search>()
                .Search
                (
                    r => r.Name,
                    searchTerms
                )
                .ProjectInto<People_Search.Result>()
                .ToList();

            return results;
        }
    }
}