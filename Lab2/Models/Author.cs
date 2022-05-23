using System;

namespace Lab2.Models
{
    [Serializable]
    public class Author
    {
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string LastName { get; set; }

        public string Workplace { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {Patronymic} {LastName}";
        }
    }
}
