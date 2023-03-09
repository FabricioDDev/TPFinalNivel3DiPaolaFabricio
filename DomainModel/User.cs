using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public enum UserType{
        Client = 0,
        Admin = 1
    }
    public class User : Person
    {
        //builder
        public User(bool usertype)
        {
            this.userType = usertype ? UserType.Admin : UserType.Client;
        }
        // Attributes
        private string Email;
        private string Password;
        public UserType userType;
        public string UrlProfileImage;//null
        //Properties
        public string EmailProperty
        {
            get { return this.Email; }
            set { this.Email = value; }
        }
        public string PassProperty
        {
            get { return this.Password; }
            set { this.Password = value; }
        }
    }
}
