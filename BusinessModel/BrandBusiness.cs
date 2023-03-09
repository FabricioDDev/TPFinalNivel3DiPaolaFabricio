using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace BusinessModel
{
    public class BrandBusiness
    {
        //Builder
        public BrandBusiness() { data = new DataAccess(); }
        //Attributes
        private DataAccess data;
    }
}
