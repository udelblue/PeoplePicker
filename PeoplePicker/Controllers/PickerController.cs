using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PeoplePicker.Models;

namespace PeoplePicker.Controllers
{
    public class PickerController : ApiController
    {
        Person[] people = new Person[] 
        { 
            new Person { Id = 1, Name = "John Smith"}, 
            new Person { Id = 2, Name = "Tommy Tester" }, 
            new Person { Id = 3, Name = "Tina Tester" }, 
            new Person { Id = 4, Name = "Jon Jones" },
            new Person { Id = 5, Name = "Jimmy Jones" },
            new Person { Id = 6, Name = "Ted Tester" }
        };

     

        public IEnumerable<Person> GetPeople(string name)
        {
            var productslist = people.Where(p => p.Name.ToLower().StartsWith(name.ToLower()));

            return productslist;
        }

    }
}
