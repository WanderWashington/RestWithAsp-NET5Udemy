using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
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
            List<Person> people = new List<Person>();
            for (int i=0; i< 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Test {i}",
                LastName = $"Test {i}",
                Address = $"address {i}",
                Gender = "Male"

            };
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id =  IncrementAndGet(),
                FirstName = "Wander",
                LastName = "Santos",
                Address ="São José dos Campos", 
                Gender = "Male"
                
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {

            return person;
        }
    }
}
