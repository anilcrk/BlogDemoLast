using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DemoFramework.Core.CrossCuttingConcerns.Security.Web
{
   public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                Name = SetName(ticket),
                LastName = SetLastName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                AuthenticationType = "Forms",
                IsAuthenticated = true
            };
            return identity;
        }
        private int SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return int.Parse(data[4]);
        }
        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }
        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];

        }
        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);//başka karakter girilirse uçuracak
            return roles;
        }
       

       

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }
    }
}
