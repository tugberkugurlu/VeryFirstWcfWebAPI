using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using Microsoft.ApplicationServer.Http.Dispatcher;
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

        [WebGet(UriTemplate = "{id}")]
        public HttpResponseMessage<Person> GetSingle(int id) {

            var person = _repo.GetSingle(id);

            if (person == null) {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.NotFound;
                response.Content = new StringContent("Country not found");
                throw new HttpResponseException(response);
            }

            var personResponse = new HttpResponseMessage<Models.Person>(person);
            personResponse.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddHours(6));
            return personResponse;
        }

    }
}