using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace BusinessModel
{
    public class ArticleBusiness
    {
        //Builder
        public ArticleBusiness()
        {
            data = new DataAccess();
        }
        //attribute
        private DataAccess data;
    }
}
