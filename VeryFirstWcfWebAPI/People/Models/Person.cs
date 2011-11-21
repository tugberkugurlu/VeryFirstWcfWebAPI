using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeryFirstWcfWebAPI.People.Models {

    public class Person {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}