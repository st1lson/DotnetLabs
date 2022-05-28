namespace Lab1.Models
{
    internal class Author
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
