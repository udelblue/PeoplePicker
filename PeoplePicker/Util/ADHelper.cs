using System;
using System.Collections.Generic;
using System.Linq;
 
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace PeoplePicker.Util
{
    public class ADHelper
    {
 
        public static List<DirectoryEntry> GetPeople(string domain, string query)
        {
            List<DirectoryEntry> list = new List<DirectoryEntry>();
 
 
            using (var context = new PrincipalContext(ContextType.Domain, domain))
            {
         
                UserPrincipal qbeUser = new UserPrincipal(context);
                qbeUser.Surname = query + "*";
                using (PrincipalSearcher srch = new PrincipalSearcher(qbeUser))
                {
                    // find all matches
                    foreach (var result in srch.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        list.Add(de);
                    }
                }
 
 
                qbeUser = new UserPrincipal(context);
                qbeUser.Name = query + "*";
 
                using (PrincipalSearcher srch = new PrincipalSearcher(qbeUser))
                {
                    // find all matches
                    foreach (var result in srch.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
             
 
                        list.Add(de);
 
 
                    }
                }
 
 
 
 
            }
            return list;
 
        }
 
        public string GetDistinguishedName(string domain, string guid)
        {
            var context = new PrincipalContext(ContextType.Domain, domain);
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.Guid, guid);
 
            return userPrincipal.DistinguishedName;
        }
 
 
 
    }
}

