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
        
        public List<GenreDTO> GetGenreWithId(int id)
        {
            return Bll.GetGenreWithId(id);
        }

        public List<ActeurDTO> GetActorWithId(int id)
        {
            return Bll.GetActorWithId(id);
        }

        public List<RealisateurDTO> GetDirectorWithId(int id)
        {
            return Bll.GetDirectorWithId(id);
        }
        public List<FilmDTO> GetFilmWithId(int id)
        {
            return Bll.GetFilmWithId(id);
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
        public void Update(UtilisateursDTO user)
        {
            BllSmart.Update(user);
        }
    }
}
