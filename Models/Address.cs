namespace PostmanAPI.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
