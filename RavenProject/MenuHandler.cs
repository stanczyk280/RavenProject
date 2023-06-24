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
                    return true;

                case "5":
                    return true;

                case "6":
                    return true;

                case "7":
                    return true;

                case "8":
                    return true;

                case "9":
                    return true;

                case "10":
                    return true;

                case "11":
                    return true;

                case "12":
                    return true;

                case "13":
                    return true;

                case "14":
                    return true;

                case "15":
                    return true;

                case "16":
                    return true;

                case "17":
                    return true;

                case "18":
                    return true;

                case "19":
                    return true;

                case "20":
                    return true;

                case "21":
                    return true;

                case "22":
                    return true;

                case "23":
                    return true;

                case "24":
                    return true;

                case "25":
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(1000);
                    return false;
            }
            return false;
        }
    }
}