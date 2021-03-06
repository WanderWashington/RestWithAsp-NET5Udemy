using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }


        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }


        public Person Create(Person person)
        {
            _repository.Create(person);
            return person;
        }

        public Person Update(Person person)
        {
            _repository.Update(person);
            return person;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
