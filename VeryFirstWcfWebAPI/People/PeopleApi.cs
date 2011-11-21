using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using VeryFirstWcfWebAPI.People.Infrastructure;
using VeryFirstWcfWebAPI.People.Models;

namespace VeryFirstWcfWebAPI.People {

    [ServiceContract]
    public class PeopleApi {

        private readonly IPeopleRepository _repo;

        public PeopleApi(IPeopleRepository repo) {
            _repo = repo;
        }

        [WebGet]
        public HttpResponseMessage<IQueryable<Person>> Get() {

            var model = _repo.GetAll();

            var responseMessage = new HttpResponseMessage<IQueryable<Person>>(model);
            responseMessage.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddHours(6));

            return responseMessage;
        }

    }
}