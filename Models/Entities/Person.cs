namespace CrudWebApi.Models.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public  string Name { get; set; }
        public  string LastName { get; set; }
        public  int Age { get; set; }
        public string Sex { get; set; }
        public string SkinColor { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
    }
}
