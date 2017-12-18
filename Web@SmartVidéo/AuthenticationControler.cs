﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_SmartVidéo.ServiceReference1;

namespace Web_SmartVidéo
{
    public class AuthenticationControler
    {
        ServiceReference1.Service1Client service;
        public AuthenticationControler()
        {
            service = new ServiceReference1.Service1Client();
        }
        public void ModifyUser(UtilisateursDTO user)
        {
            service.UpdateUser(user);
        }
        public UtilisateursDTO findUser(string email)
        {
            return service.findUser(email);
        }
        public string Login(string email,string password)
        {
            return service.Login(email, password);
        }
        public Boolean InsertUser(UtilisateursDTO user)
        {
            return service.InsertUser(user);
        }
        public FilmDTO[] LoadFilm(int debut, int fin)
        {
            return service.GetFilms(debut, fin);
        }
    }
}