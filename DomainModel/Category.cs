using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Category
    {
        //Attributes
        public int Id { get; set; }
        public string Name { get; set; }

        //Override
        public override string ToString()
        {
            return this.Name;
        }
    }
}
