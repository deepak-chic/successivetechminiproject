using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace SuccessiveTechiniProject.WebAPI.Controllers
{
    public class PersonController : ApiController
    {
        private IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        // GET api/person
        public IEnumerable<Person> Get()
        {            
            return _personRepo.GetAll().ToList();
        }

        // GET api/person/5
        // Speciically use HttpResponseMessage
        // what i have written here is the default behavior of web API means what content negotiation web api does internally
        // but if we want to write our own content negotiation then follow this URL https://www.infoworld.com/article/3083273/how-to-work-with-content-negotiation-in-web-api.html
        public HttpResponseMessage Get(int id)
        {
            //=================================================
            // Through Content Negotiation
            //================================================

            Person person = _personRepo.GetAll().Where(p => p.Id == id).FirstOrDefault();

            //IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

            //ContentNegotiationResult result = negotiator.Negotiate(
            //    typeof(Person), this.Request, this.Configuration.Formatters);
            //if (result == null)
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            //    throw new HttpResponseException(response);
            //}

            //return new HttpResponseMessage()
            //{
            //    Content = new ObjectContent<Person>(
            //        person,                // What we are serializing 
            //        result.Formatter,           // The media formatter
            //        result.MediaType.MediaType  // The MIME type
            //    )
            //};

            //=================================================
            // Default http response message
            //================================================

              return Request.CreateResponse(HttpStatusCode.OK, person);

            //http://localhost:18041/api/values
        }

        // POST api/person
        [HttpPost]
        [ActionName("SavePerson")]

        public void Post([FromBody]Person value)
        {
            _personRepo.Add(value);
            _personRepo.Save();
        }

        // PUT api/person/5
        public void Put(int id, [FromBody]Person value)
        {
            _personRepo.Edit(value);
            _personRepo.Save();
        }

        // DELETE api/person/5
        public void Delete(int id)
        {
            var person = _personRepo.GetAll().Where(p => p.Id == id).FirstOrDefault();
            _personRepo.Delete(person);
            _personRepo.Save();
        }
    }
}
