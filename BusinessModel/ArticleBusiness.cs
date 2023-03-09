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

        public void Insert(Article article)
        {
            try
            {
                data.Query("insert into ARTICULOS values (@Code, @Name, @Description, @Bid, @Cid, @Img, @Price);");
                data.Parameters("@Code", article.Code);
                data.Parameters("@Name", article.Name);
                data.Parameters("@Description", article.Description);
                data.Parameters("@Bid", article.Brand.Id);
                data.Parameters("@Cid", article.Category.Id);
                data.Parameters("@Img", article.Image);
                data.Parameters("@Price", article.Price);
                data.Execute();
            }
            catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }

        public void Update(Article article)
        {
            try
            {
                data.Query("update ARTICULOS set Codigo = @Code, Nombre= @Name, Descripcion= @Description, IdMarca= @IdBrand, IdCategoria= @IdCategory, ImagenUrl= @Img, Precio= @Price where Id = @Id");
                data.Parameters("@Code", article.Code);
                data.Parameters("@Name", article.Name);
                data.Parameters("@Description", article.Description);
                data.Parameters("@IdBrand", article.Brand.Id);
                data.Parameters("@IdCategory", article.Category.Id);
                data.Parameters("@Img", article.Image);
                data.Parameters("@Price", article.Price);
                data.Parameters("@Id", article.Id);
                data.Execute();
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}
