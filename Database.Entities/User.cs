using System;

namespace Database.Entities
{
    public class User
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{ID} {Name} {DateOfBirth.ToShortDateString()} {Age}";
        }
    }
}
