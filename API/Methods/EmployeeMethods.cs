using API.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Methods
{
    public class EmployeeMethods : EmployeeRepo
    {
        public void DisplayEmployee(string id)
        {
            if (!id.Contains("employees/"))
            {
                id = "employees/" + id;
            }

            var employee = GetEmployee(id);
            if (employee == null)
            {
                Console.WriteLine("No employee of given id exists");
                return;
            }

            Console.WriteLine("Id: " + employee.Id);
            Console.WriteLine("Name: " + employee.Name);
            Console.WriteLine("LastName: " + employee.LastName);
            Console.WriteLine("BirthDate: " + employee.BirthDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Country: " + employee.Country);
            Console.WriteLine("City: " + employee.City);
            Console.WriteLine("Street: " + employee.Street);
            Console.WriteLine("PostalCode: " + employee.PostalCode);
            Console.WriteLine("Email: " + employee.Email);
            Console.WriteLine("PhoneNumber: " + employee.PhoneNumber);
            Console.WriteLine("AccessLevel: " + employee.AccessLevel);
        }

        public void DisplayEmployeesList()
        {
            var employees = GetEmployees();
            foreach (var employee in employees)
            {
                DisplayEmployee(employee.Id);
                Console.WriteLine("========================\n");
            }
        }

        public void DisplayEmployeesListSimple()
        {
            Console.WriteLine("Please enter desired page number: ");
            int pagenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter desired page size: ");
            int pagesize = Convert.ToInt32(Console.ReadLine());

            var employees = GetEmployeesByNameAndLastNameWithPaging(pagenumber, pagesize);
            foreach (var employee in employees)
            {
                int i = 1;
                Console.WriteLine(i + ". Name: " + employee.Name + " " + employee.LastName + ", Email" + employee.Email);
                i++;
            }
        }

        public void DisplayEmployeesAccessLevel()
        {
            Console.WriteLine("Please enter desired page number: ");
            int pagenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter desired page size: ");
            int pagesize = Convert.ToInt32(Console.ReadLine());

            var employees = GetEmployeesByAccessLevelWithPaging(pagenumber, pagesize);
            foreach (var employee in employees)
            {
                int i = 1;
                Console.WriteLine(i + ". Name: " + employee.Name + " " + employee.LastName + ", Access Level" + employee.AccessLevel);
                i++;
            }
        }

        public void DisplayAccessLevelCount()
        {
            var results = GetEmployeesAccessCount();
            foreach (var result in results)
            {
                Console.WriteLine("Access level: " + result.AccessLevel + " Total number of employees with access: " + result.TotalCount);
            }
        }

        public void CreateEmployee()
        {
            Console.WriteLine("Add new employee to the system\n");
            Console.WriteLine("Please enter correct values\n");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("\nLast Name: ");
            string lastName = Console.ReadLine();
            Console.Write("\nBirth Date (Year, Month, Day): ");
            string birthDateString = Console.ReadLine();
            DateOnly birthDate = DateOnly.Parse(birthDateString);
            Console.Write("\nCountry: ");
            string country = Console.ReadLine();
            Console.Write("\nCity: ");
            string city = Console.ReadLine();
            Console.Write("\nStreet: ");
            string street = Console.ReadLine();
            Console.Write("\nPostal Code: ");
            string postalCode = Console.ReadLine();
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            Console.Write("\nPhone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("\nAccess Level: ");
            string accessLevel = Console.ReadLine();

            Employee employee = new Employee()
            {
                Name = name,
                LastName = lastName,
                BirthDate = birthDate,
                Country = country,
                City = city,
                Street = street,
                PostalCode = postalCode,
                Email = email,
                PhoneNumber = phoneNumber,
                AccessLevel = accessLevel
            };

            CreateEmployee(employee);
        }

        public void UpdateEmployee(string id)
        {
            id = "employees/" + id;
            var employee = GetEmployee(id);
            if (employee == null)
            {
                Console.WriteLine("No employee of " + id + " exists");
                return;
            }

            Console.WriteLine("Update employee in the system\n");
            Console.WriteLine("Please enter correct values or leave them empty if you do not wish to change the value\n");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            string newName = string.IsNullOrEmpty(name) ? employee.Name : name;

            Console.Write("\nLast Name: ");
            string lastName = Console.ReadLine();
            string newLastName = string.IsNullOrEmpty(lastName) ? employee.LastName : lastName;

            Console.Write("\nBirth Date (Year, Month, Day): ");
            string birthDateString = Console.ReadLine();
            DateOnly birthDate = string.IsNullOrEmpty(birthDateString) ? employee.BirthDate : DateOnly.Parse(birthDateString);

            Console.Write("\nCountry: ");
            string country = Console.ReadLine();
            string newCountry = string.IsNullOrEmpty(country) ? employee.Country : country;

            Console.Write("\nCity: ");
            string city = Console.ReadLine();
            string newCity = string.IsNullOrEmpty(city) ? employee.City : city;

            Console.Write("\nStreet: ");
            string street = Console.ReadLine();
            string newStreet = string.IsNullOrEmpty(street) ? employee.Street : street;

            Console.Write("\nPostal Code: ");
            string postalCode = Console.ReadLine();
            string newPostalCode = string.IsNullOrEmpty(postalCode) ? employee.PostalCode : postalCode;

            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            string newEmail = string.IsNullOrEmpty(email) ? employee.Email : email;

            Console.Write("\nPhone Number: ");
            string phoneNumber = Console.ReadLine();
            string newPhoneNumber = string.IsNullOrEmpty(phoneNumber) ? employee.PhoneNumber : phoneNumber;

            Console.Write("\nAccess Level: ");
            string accessLevel = Console.ReadLine();
            string newAccessLevel = string.IsNullOrEmpty(accessLevel) ? employee.AccessLevel : accessLevel;

            Employee newEmployee = new Employee()
            {
                Id = employee.Id,
                Name = newName,
                LastName = newLastName,
                BirthDate = birthDate,
                Country = newCountry,
                City = newCity,
                Street = newStreet,
                PostalCode = newPostalCode,
                Email = newEmail,
                PhoneNumber = newPhoneNumber,
                AccessLevel = newAccessLevel
            };

            UpdateEmployee(id, newEmployee);
        }

        public void DeleteEmployeeFromSystem(string id)
        {
            id = "employees/" + id;
            var employee = GetEmployee(id);
            if (employee == null)
            {
                Console.WriteLine("No employee of given id exists");
                return;
            }
            DeleteEmployee(id);
        }
    }
}