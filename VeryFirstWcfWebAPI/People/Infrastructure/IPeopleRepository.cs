using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeryFirstWcfWebAPI.People.Models;

namespace VeryFirstWcfWebAPI.People.Infrastructure {

    public interface IPeopleRepository {

        IQueryable<Person> GetAll();
        Person GetSingle(int id);
    }
}