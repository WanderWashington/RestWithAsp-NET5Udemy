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
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }


        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }


        public Book Create(Book Book)
        {
            _repository.Create(Book);
            return Book;
        }

        public Book Update(Book Book)
        {
            _repository.Update(Book);
            return Book;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
