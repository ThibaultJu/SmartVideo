using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
        public List<FilmDTO> RechercheFilmbyName(string name)
        {

            return service.GetFilmByName(name).ToList();
        }
        public List<ActeurDTO> RechercheActorByName(string name)
        {
            return service.GetActorByName(name).ToList();
        }
        public List<FilmDTO>  RechercheFilmByActors (List<ActeurDTO> listActors)
        {
            List<FilmDTO> ListFilms = new List<FilmDTO>();
            foreach(ActeurDTO act in listActors)
            {
                ListFilms.AddRange(service.GetFilmByActors(act.Id));
            }

            return ListFilms;
        }
        public List<FilmDTO> LoadFilm(int debut,int nbre)
        {
            List<FilmDTO> listFilms = new List<FilmDTO>();
            List<FilmDTO> tmp = new List<FilmDTO>();
            int i=5;
            while(i<=nbre)
            {
                tmp= (service.GetFilms(debut, 5)).ToList();
                debut = i;
                i = i + 5;
                listFilms.AddRange(tmp);
            }
            return listFilms;
        }
        public FilmDTO GetFilm(int id)
        {
            return (service.GetFilmById(id)).ToList().First();

        }
    }
}