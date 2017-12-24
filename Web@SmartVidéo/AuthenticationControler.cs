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
            List<FilmDTO> list = new List<FilmDTO>();
            list = service.GetFilmByName(name).ToList();
            foreach(FilmDTO f in list)
            {
                service.InsertHits(f.Id,"Film");
            }
            return list;
        }
        public List<ActeurDTO> RechercheActorByName(string name)
        {
            List<ActeurDTO> list = new List<ActeurDTO>();
            list = service.GetActorByName(name).ToList();
            foreach (ActeurDTO f in list)
            {
                service.InsertHits(f.Id, "Acteur");
            }
            return list;
        }
        public ActeurDTO RechercheActorByID(int id)
        {
            return (service.GetActorById(id).ToList()).First();
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
        public Boolean InsertLocation(int id,String user,int duree)
        {
            return service.InsertLocation(id,user,duree);
        }
        public List<LocationDTO> GetLocation(string user)
        {
            return service.getLocation(user).ToList();
        }
        public List<StatistiquesDTO> getStatistiques()
        {
            return service.getStatistiques().ToList();
        }
    }

}