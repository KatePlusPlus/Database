using Database.BLL;
using Database.Entities;
using System;
using System.Linq;

namespace Database.PL
{
    class PLLogic
    {
        private static UserLogic userLogic = new UserLogic();

        public static void Add()
        {
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter date of birth (DD.MM.YYYY)");
            var dateOfBirth = DateTime.Parse(Console.ReadLine());

            var age = (new DateTime(1, 1, 1) + DateTime.Today.Subtract(dateOfBirth)).Year - 1;

            var currentStudent = new User()
            {
                Name = name,
                DateOfBirth = dateOfBirth,
                Age = age
            };

            userLogic.Add(currentStudent);
        }

        public static void Remove()
        {
            Console.WriteLine("Enter ID");
            var ID = int.Parse(Console.ReadLine());

            userLogic.Remove(ID);
        }

        public static void GetAll()
        {
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
            }
        }

        public static void GetByName()
        {
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();

            var result = userLogic.GetByName(name).ToList();

            foreach (var user in result)
            {
                Console.WriteLine(user);
            }
        }

        public static void OrderByDateOfBirth()
        {
            var result = userLogic.OrderByDateOfBirth().ToList();

            foreach (var user in result)
            {
                Console.WriteLine(user);
            }
        }
    }
}
