using API.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenProject
{
    public class MenuHandler
    {
        protected BookMethods bookMethods = new BookMethods();
        protected ClientMethods clientMethods = new ClientMethods();
        protected EmployeeMethods employeesMethods = new EmployeeMethods();

        public List<string> mainMenu = new List<string>
        {
            "Welcome to Dusty Library Management software\n",
            "Please choose wanted option from the list below:\n",
            "===Book Operations===",
            "1. Display Books",
            "2. Display Book List",
            "3. Display Simplified Books List",
            "4. Display Category Count",
            "5. Add New Book To The System",
            "6. Update Existing Book Informations",
            "7. Delete Book From The System",
            "===Employee Operations===",
            "8. Display Employee",
            "9. Display Employees List",
            "10. Display Simplified Employees List",
            "11. Display Employee Access Level List",
            "12. Display Employee Access Level Count",
            "13. Add New Employee",
            "14. Update Existing Employee Informations",
            "15. Delete Employee From The System",
            "===Client Operations===",
            "16. Display Client",
            "17. Display Clients List",
            "18. Display Simplified Clients List",
            "19. Add New Client",
            "20. Update Existing Client Informations",
            "21. Delete Client From The System",
            "22. Display Client's Rental List",
            "23. Rent Book To Client",
            "24. Return Book",
            "25. Exit"
        };

        public void DisplayMenu()
        {
            Console.Clear();
            foreach (string item in mainMenu)
            {
                Console.WriteLine(item);
            }
        }

        public void ReturnToMenu()
        {
            Console.WriteLine("\nPress a button to return");
            Console.ReadLine();
            Console.Clear();
            DisplayMenu();
        }

        public bool MainMenu()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Enter book id: ");
                    bookMethods.DisplayBook(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "2":
                    Console.Clear();
                    bookMethods.DisplayBooksList();
                    ReturnToMenu();
                    return true;

                case "3":
                    Console.Clear();
                    bookMethods.DisplayBooksAuthorList();
                    ReturnToMenu();
                    return true;

                case "4":
                    Console.Clear();
                    bookMethods.DisplayCategoryCount();
                    ReturnToMenu();
                    return true;

                case "5":
                    Console.Clear();
                    bookMethods.CreateBook();
                    ReturnToMenu();
                    return true;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Enter book id: ");
                    bookMethods.UpdateBook(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "7":
                    Console.Clear();
                    Console.WriteLine("Enter book id: ");
                    bookMethods.DeleteBook(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "8":
                    Console.Clear();
                    Console.WriteLine("Enter employee id: ");
                    employeesMethods.DisplayEmployee(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "9":
                    Console.Clear();
                    employeesMethods.DisplayEmployeesList();
                    ReturnToMenu();
                    return true;

                case "10":
                    Console.Clear();
                    employeesMethods.DisplayEmployeesListSimple();
                    ReturnToMenu();
                    return true;

                case "11":
                    Console.Clear();
                    employeesMethods.DisplayEmployeesAccessLevel();
                    ReturnToMenu();
                    return true;

                case "12":
                    Console.Clear();
                    employeesMethods.DisplayAccessLevelCount();
                    ReturnToMenu();
                    return true;

                case "13":
                    Console.Clear();
                    employeesMethods.CreateEmployee();
                    ReturnToMenu();
                    return true;

                case "14":
                    Console.Clear();
                    Console.WriteLine("Enter employee id: ");
                    employeesMethods.UpdateEmployee(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "15":
                    Console.Clear();
                    Console.WriteLine("Enter employee id: ");
                    employeesMethods.DeleteEmployee(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "16":
                    Console.Clear();
                    Console.WriteLine("Enter client id: ");
                    clientMethods.DisplayClient(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "17":
                    Console.Clear();
                    clientMethods.DisplayClientsList();
                    ReturnToMenu();
                    return true;

                case "18":
                    Console.Clear();
                    clientMethods.DisplayClientsListSimple();
                    ReturnToMenu();
                    return true;

                case "19":
                    Console.Clear();
                    clientMethods.CreateClient();
                    ReturnToMenu();
                    return true;

                case "20":
                    Console.Clear();
                    Console.WriteLine("Enter client id: ");
                    clientMethods.UpdateClient(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "21":
                    Console.Clear();
                    Console.WriteLine("Enter client id: ");
                    clientMethods.DeleteClient(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "22":
                    Console.Clear();
                    Console.WriteLine("Enter client id: ");
                    clientMethods.DisplayRentalList(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "23":
                    Console.Clear();
                    Console.WriteLine("Enter client id: ");
                    clientMethods.RentBook(Console.ReadLine());
                    ReturnToMenu();
                    return true;

                case "24":
                    Console.Clear();
                    clientMethods.ReturnBook();
                    ReturnToMenu();
                    return true;

                case "25":
                    Console.WriteLine("Exiting...");
                    return false;
            }
            return false;
        }
    }
}