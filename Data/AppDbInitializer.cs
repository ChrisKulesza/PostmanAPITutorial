using PostmanAPI.Models;

namespace PostmanAPI.Data
{
    public class AppDbInitializer
    {
        private readonly AppDbContext _context;

        public AppDbInitializer(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Seeding data to the database if database is empty.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // add Person data to the database.
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Make the database context available.
                var _context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // Check whether the table Persons in the database contains data records.
                if (!_context.Persons.Any())
                {
                    // Defining persons seeding data
                    var person1 = new Person
                    {
                        FirstName = "Max",
                        LastName = "Mustermann",
                        StreetName = "Musterstraße",
                        StreetNumber = "1",
                        City = "Musterstadt",
                        PostalCode = "12345"
                    };

                    var person2 = new Person
                    {
                        FirstName = "Erika",
                        LastName = "Mustermann",
                        StreetName = "Musterstraße",
                        StreetNumber = "1",
                        City = "Musterstadt",
                        PostalCode = "12345"
                    };
                    
                    var person3 = new Person
                    {
                        FirstName = "John",
                        LastName = "Joe",
                        StreetName = "Any Street",
                        StreetNumber = "1",
                        City = "Any City",
                        PostalCode = "12345"
                    };

                    var person4 = new Person
                    {
                        FirstName = "Jane",
                        LastName = "Joe",
                        StreetName = "Any Street",
                        StreetNumber = "1",
                        City = "Any City",
                        PostalCode = "12345"
                    };
                    // If there are no records then create the following.
                    _context.Persons.AddRange(person1, person2, person3, person4);
                }

                _context.SaveChanges();
            }
        }
    }
}
