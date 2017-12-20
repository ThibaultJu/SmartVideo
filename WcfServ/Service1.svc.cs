using BLL;
using BLLSmartVideoDB;
using FilmDTOLibrary;
using SmartVideoDBDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [CollectionDataContract]
    public class Service1 : IService1
    {
        BLLClass Bll = new BLLClass();
        BLLSmartVideo BllSmart = new BLLSmartVideo();

        public List<FilmDTO> GetFilms(int debut, int nb)
        {
            return Bll.GetFilms(debut, nb);
        }
        
        public List<GenreDTO> GetGenreById(int id)
        {
            return Bll.GetGenreById(id);
        }

        public List<ActeurDTO> GetActorById(int id)
        {
            return Bll.GetActorById(id);
        }

        public List<ActeurDTO> GetActorByName(string name)
        {
            return Bll.GetActorByName(name);
        }
        public List<FilmDTO> GetFilmByActors(int id)
        {
            return Bll.GetFilmByActors(id);
        }
        public List<RealisateurDTO> GetDirectorById(int id)
        {
            return Bll.GetDirectorById(id);
        }
        public List<FilmDTO> GetFilmById(int id)
        {
            return Bll.GetFilmById(id);
        }
        public List<FilmDTO> GetFilmByName(string name)
        {
            return Bll.GetFilmByName(name);
        }
        public void SetTrailer(int id, String trailer)
        {
            Bll.SetTrailer(id, trailer);
        }
        public String Login(string E, string pass)
        {
            return BllSmart.Login(E, pass);
        }
        public UtilisateursDTO findUser(string E)
        {
            return BllSmart.findUser(E);
        }
        public void UpdateUser(UtilisateursDTO user)
        {
            BllSmart.UpdateUser(user);
        }
        public Boolean InsertUser(UtilisateursDTO user)
        {
            return BllSmart.InsertUser(user);
        }
    }
}
