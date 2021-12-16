using PostmanAPI.Models;

namespace PostmanAPI.Data
{
    public class AppDbInitializer
    {
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
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // Check whether the table Persons in the database contains data records.
                if (!context.Persons.Any())
                {
                    // If there are no records then create the following.
                    context.Persons.AddRange(
                        // Nested Object Initializers
                        // https://fuqua.io/blog/2020/12/a-lesser-known-csharp-feature-nested-object-initializers/
                        // Person 1
                        new Person
                        {
                            FirstName = "Max",
                            LastName = "Mustermann",
                            Address = new()
                            {
                                new Address
                                {
                                    StreetName = "Musterstrasse",
                                    StreetNumber = 1,
                                    City = "Musterstadt",
                                    PostalCode = "12345"
                                }
                            }
                        },
                        // Person 2
                        new Person
                        {
                            FirstName = "Erika",
                            LastName = "Mustermann",
                            Address = new()
                            {
                                new Address
                                {
                                    StreetName = "Musterstrasse",
                                    StreetNumber = 1,
                                    City = "Musterstadt",
                                    PostalCode = "12345"
                                }
                            }
                        },
                        // Person 3
                        new Person
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            Address = new()
                            {
                                new Address
                                {
                                    StreetName = "Any Street",
                                    StreetNumber = 1,
                                    City = "Any City",
                                    PostalCode = "12345"
                                }
                            }
                        },
                        // Person 4
                        new Person
                        {
                            FirstName = "Jane",
                            LastName = "Doe",
                            Address = new()
                            {
                                new Address
                                {
                                    StreetName = "Any Street",
                                    StreetNumber = 1,
                                    City = "Any City",
                                    PostalCode = "12345"
                                }
                            }
                        });
                }
                context.SaveChanges();
            }
        }
    }
}
