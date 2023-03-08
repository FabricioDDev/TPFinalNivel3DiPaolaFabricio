using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DomainModel;

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

        //Methods
        //leer, insertar, modificar, borrar
        public List<Article> Listing()
        {
            List<Article> List = new List<Article>();
            try
            {
                data.Query("SELECT A.Id as IdArticle, Codigo, Nombre, A.Descripcion as Adescription, ImagenUrl, Precio, M.Id as IdBrand, M.Descripcion as Bdescription, C.Id as IdCategory, C.Descripcion AS Cdescription from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                data.Read();
                while (data.readerProp.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.readerProp["IdArticle"];
                    aux.Code = (int)data.readerProp["Codigo"];
                    aux.Name = (string)data.readerProp["Nombre"];
                    aux.Description = (string)data.readerProp["Adescription"];
                    aux.Image = (string)data.readerProp["ImagenUrl"];
                    aux.Price = (decimal)data.readerProp["Precio"];
                    aux.Brand = new Brand();
                    aux.Brand.Id = (int)data.readerProp["IdBrand"];
                    aux.Brand.Name = (string)data.readerProp["Bdescription"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.readerProp["IdCategory"];
                    aux.Category.Name = (string)data.readerProp["Cdescription"];
                    List.Add(aux);
                }
                return List;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}
