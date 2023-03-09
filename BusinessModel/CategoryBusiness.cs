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

        //Methods
        public List<Brand> Listing()
        {
            List<Brand> list = new List<Brand>();
            try
            {
                data.Query("select Id, Descripcion from CATEGORIAS");
                data.Read();
                while (data.readerProp.Read())
                {
                    Brand aux = new Brand();
                    aux.Id = (int)data.readerProp["Id"];
                    aux.Name = (string)data.readerProp["Descripcion"];
                    list.Add(aux);
                }
                return list;
            }
            catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}
