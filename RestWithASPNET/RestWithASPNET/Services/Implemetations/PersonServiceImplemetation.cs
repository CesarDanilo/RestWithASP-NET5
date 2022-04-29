using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNET.Services.Implemetations
{
    public class PersonServiceImplemetation : IPersonService
    {

        private readonly MySQLContext _context;

        // Contrutor
        public PersonServiceImplemetation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Cesar",
                LastName = "Ortega",
                Address = "Dourados - MS",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {

            return person;
        }
 
    }
}
