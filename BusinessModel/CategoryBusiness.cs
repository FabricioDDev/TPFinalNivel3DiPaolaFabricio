using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace BusinessModel
{
    public class CategoryBusiness
    {
        //Builder
        public CategoryBusiness()
        {
            data = new DataAccess();
        }
        //Attributes
        private DataAccess data;
    }
}
