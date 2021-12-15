namespace PostmanAPI.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> Address { get; set; }
    }
}
