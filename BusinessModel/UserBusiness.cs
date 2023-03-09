using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace BusinessModel
{
    public class UserBusiness
    {
        //Builder
        public UserBusiness() { this.data = new DataAccess(); }
        //Attributes
        private DataAccess data;
    }
}
