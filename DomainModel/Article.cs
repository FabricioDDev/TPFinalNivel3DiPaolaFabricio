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
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        //Override
        public override string ToString()
        {
            return this.Name;
        }
    }
}
