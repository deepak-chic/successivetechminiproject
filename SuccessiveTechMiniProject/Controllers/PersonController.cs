using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuccessiveTechMiniProject.Controllers
{
    public class PersonController : Controller
    {
        private WebApIHelper<Person> _webApiHelper;

        public PersonController(WebApIHelper<Person> webApiHelper)
        {
            _webApiHelper = webApiHelper;
        }

        // GET: Person
        public ActionResult Index()
        {            
            IList<Person> persons = _webApiHelper.GetAll("person");
            return View(persons);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            Person person = _webApiHelper.Get("person/" + id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    int result = _webApiHelper.Create("person", person);
                    if (result == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    }
                }

                ModelState.AddModelError(string.Empty, "Unable to save changes.");

                return View(person);               
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = _webApiHelper.Get("person/" + id);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _webApiHelper.Edit("person/" + id, person);
                    if (result == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    }
                }

                ModelState.AddModelError(string.Empty, "Unable to edit.");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            Person person = _webApiHelper.Get("person/" + id);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _webApiHelper.Delete("person/" + id);
                    if (result == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    }
                }

                ModelState.AddModelError(string.Empty, "Unable to delete.");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
