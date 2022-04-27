﻿using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNET.Services.Implemetations
{
    public class PersonServiceImplemetation : IPersonService
    {

        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {

            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
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

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person name" + i,
                LastName = "Person LastName" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {

            return Interlocked.Increment(ref count);
        }
    }
}
