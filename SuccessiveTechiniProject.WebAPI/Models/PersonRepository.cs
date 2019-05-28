using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SuccessiveTechiniProject.WebAPI
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        SuccessiveTechDBContext dBContext = new SuccessiveTechDBContext();

        public void Add(Person entity)
        {
            dBContext.Persons.Add(entity);            
        }

        public void Delete(Person entity)
        {
            dBContext.Persons.Remove(entity);
        }

        public void Dispose()
        {
            dBContext.Dispose();
        }

        public void Edit(Person entity)
        {
            var oldEntity = dBContext.Persons.Where(p => p.Id == entity.Id).FirstOrDefault();
            oldEntity.FirstName = entity.FirstName;
            oldEntity.LastName = entity.LastName;
            oldEntity.PhoneNumber = entity.PhoneNumber;
        }

        public IQueryable<Person> FindBy(Expression<Func<Person, bool>> predicate)
        {
            return dBContext.Set<Person>().Where(predicate);
        }

        public IQueryable<Person> GetAll()
        {
            return dBContext.Persons;
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }
    }
}