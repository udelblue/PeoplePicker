using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PeoplePicker.Models;
using PeoplePicker.Util;

namespace PeoplePicker.Controllers
{
    public class PickerController : ApiController
    {
        //Person[] people = new Person[] 
        //{ 
        //    new Person { Id = 1, Name = "John Smith"}, 
        //    new Person { Id = 2, Name = "Tommy Tester" }, 
        //    new Person { Id = 3, Name = "Tina Tester" }, 
        //    new Person { Id = 4, Name = "Jon Jones" },
        //    new Person { Id = 5, Name = "Jimmy Jones" },
        //    new Person { Id = 6, Name = "Ted Tester" }
        //};

     

        public IEnumerable<Person> GetPeople(string name)
        {
            string domain = "google.com";
            List<Person> peoplelist = new List<Person>();
             List<DirectoryEntry> del = ADHelper.GetPeople(domain , name);
             if (del.Count >= 1)
             {
                 foreach (var de in del)
                 {
                     Person p = new Person();
                     p.Name = de.Properties["givenName"].Value + " " + de.Properties["sn"].Value;
                     peoplelist.Add(p);
                 }
             }

           // var productslist = people.Where(p => p.Name.ToLower().StartsWith(name.ToLower()));

            return peoplelist;
        }

    }
}
