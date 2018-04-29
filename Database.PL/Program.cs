using System;

namespace Database.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose action");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Remove user by ID");
            Console.WriteLine("3. Print all users");
            Console.WriteLine("4. Print all users with specified name");
            Console.WriteLine("5. Print all users ordered by date of birth");

            while (true)
            {
                Console.WriteLine("Choose action");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        PLLogic.Add();
                        break;
                    case "2":
                        PLLogic.Remove();
                        break;
                    case "3":
                        PLLogic.GetAll();
                        break;
                    case "4":
                        PLLogic.GetByName();
                        break;
                    case "5":
                        PLLogic.OrderByDateOfBirth();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
