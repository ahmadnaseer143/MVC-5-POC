using Microsoft.AspNetCore.Mvc;
using MVC5_POC.Models;

namespace MVC5_POC.Controllers
{
    public class PersonController : Controller
    {
        private static List<PersonModel> people = new List<PersonModel>
        {
            new PersonModel { Id = 1, Name = "Naseer Ahmad", Age = 25, IsAlive = true },
            new PersonModel { Id = 2, Name = "Ahmad", Age = 25, IsAlive = true },
            new PersonModel { Id = 3, Name = "Alishba Iftikhar", Age = 25, IsAlive = true },
            new PersonModel { Id = 4, Name = "Saleh Ahmad", Age = 25, IsAlive = true }
        };
        public IActionResult Index()
        {
            return View(people);
        }
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                int newId = people.Count + 1;
                person.Id = newId;
                people.Add(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult EditPerson(int id)
        {
            var person = people.Find(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // Add the POST action to handle the form submission
        [HttpPost]
        public IActionResult EditPerson(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = people.Find(p => p.Id == person.Id);
                if (existingPerson == null)
                {
                    return NotFound();
                }
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                existingPerson.IsAlive = person.IsAlive;
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult DeletePerson(int id)
        {
            var person = people.Find(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult DeletePerson(int id, string confirm)
        {
            var person = people.Find(p => p.Id == id);
            if (person != null && confirm == "Yes")
            {
                people.Remove(person);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
