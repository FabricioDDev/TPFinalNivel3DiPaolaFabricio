using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace BusinessModel
{
    public class FavoriteBusiness
    {
        public FavoriteBusiness() { data = new DataAccess(); }
        private DataAccess data;

        public List<Favorites> Listing(int IdU)
        {
            List<Favorites> list = new List<Favorites>();
            data.Query("select Id, IdUser, IdArticulo from FAVORITOS where IdUser = IdU ");
            data.Parameters("IdU", IdU);
            data.Read();
            while (data.readerProp.Read())
            {
                Favorites aux = new Favorites();
                aux.Id = (int)data.readerProp["Id"];
                aux.IdUser = (int)data.readerProp["IdUser"];
                aux.IdArticle = (int)data.readerProp["IdArticulo"];
                list.Add(aux);
            }
            return list;
        }
        public void insertFavorite(int IdUser, int IdArticle)
        {
            data.Query("insert into FAVORITOS values (@IdUser, @IdArticulo)");
            data.Parameters("@IdUser", IdUser);
            data.Parameters("@IdArticulo", IdArticle);
            data.Execute();
        }
        public void deleteFavorite(int Id)
        {
            data.Query("delete FAVORITOS where Id = @Id");
            data.Parameters("@Id", Id);
            data.Execute();
        }
    }
}
