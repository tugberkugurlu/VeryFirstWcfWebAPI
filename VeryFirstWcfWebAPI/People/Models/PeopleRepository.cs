using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeryFirstWcfWebAPI.People.Infrastructure;

namespace VeryFirstWcfWebAPI.People.Models {

    public class PeopleRepository : IPeopleRepository {

        public IQueryable<Person> GetAll() {

            IList<Person> people = new List<Person>();

            for (int i = 1; i < 10; i++) {
                people.Add(new Person { 
                    ID = i,
                    Name = string.Format("{0}_{1}", "PersonName", i),
                    Surname = string.Format("{0}_{1}", "PersonSurname", i),
                    Age = i*5
                });
            }

            return people.AsQueryable();
        }

        public Person GetSingle(int id) {

            var person = GetAll().SingleOrDefault(x => x.ID == id);
            return person;
        }
    }
}