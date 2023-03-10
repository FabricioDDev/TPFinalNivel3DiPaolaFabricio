﻿using System;
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
        //Methods
        public User LogIn(string pass, string email)
        {
            try
            {
                data.Query("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                data.Parameters("@email", email);
                data.Parameters("@pass", pass);
                data.Read();
                while (data.readerProp.Read())
                {
                    User aux = new User((bool)data.readerProp["admin"]);
                    aux.idProperty = (int)data.readerProp["Id"];
                    aux.EmailProperty = (string)data.readerProp["email"];
                    aux.PassProperty = (string)data.readerProp["pass"];
                    aux.nameProperty = ((object)data.readerProp["nombre"] ?? DBNull.Value).ToString();
                    aux.lastNameProperty = ((object)data.readerProp["apellido"] ?? DBNull.Value).ToString();
                    aux.UrlProfileImage = ((object)data.readerProp["urlImagenPerfil"] ?? DBNull.Value).ToString();
                    return aux;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
        public void Insert(User user)
        {
            try
            {
                data.Query("insert into USERS values (@email, @pass, @nombre, @apellido, @urlImagenPerfil, @admin)");
                data.Parameters("@email", user.EmailProperty);
                data.Parameters("@pass", user.PassProperty);
                data.Parameters("@nombre", (object)user.nameProperty?? DBNull.Value);
                data.Parameters("@apellido", (object)user.lastNameProperty ?? DBNull.Value);
                data.Parameters("@urlImagenPerfil", (object)user.UrlProfileImage ?? DBNull.Value);
                data.Parameters("@admin", user.userType);
                data.Execute();
            }
            catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}
