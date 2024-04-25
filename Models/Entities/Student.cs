namespace StudentPortal.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Maths { get; set; }

        public int Science { get; set; }

        public int Arts { get; set; }

        public int Total { get; set; }
    }
}
