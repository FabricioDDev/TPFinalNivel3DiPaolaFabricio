using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Article
    {
        //Attributes
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Double Price { get; set; }

        //Override
        public override string ToString()
        {
            return this.Name;
        }
    }
}
