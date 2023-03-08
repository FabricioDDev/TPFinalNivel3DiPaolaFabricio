using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class Person
    {
        //Attributes
        private int Id;
        private string Name;//null
        private string LastName;//null

        //properties
        public int idProperty
        {
            get { return this.Id; }
            set { this.Id = value; }
        }
        public string nameProperty
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public string lastNameProperty
        {
            get { return this.LastName; }
            set { this.LastName = value; }
        }
    }
}
