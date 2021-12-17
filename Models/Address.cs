namespace PostmanAPI.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Navigation Properties
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
