using System.Data.SqlClient;
using DAL;
using FilmDTOLibrary;
using System.Collections.Generic;

namespace BLL
{
    public class BLLClass
    {
        public BLLClass()
        {

        }

        public List<FilmDTO> GetFilms(int debut, int nb)
        {
            return DalSingleton.Singleton().GetFilms(debut, nb);
        }

        public List<GenreDTO> GetGenreById(int id)
        {
            return DalSingleton.Singleton().GetGenreById(id);
        }

        public List<ActeurDTO> GetActorById(int id)
        {
            return DalSingleton.Singleton().GetActorById(id);
        }
        public List<ActeurDTO> GetActorByName(string name)
        {
            return DalSingleton.Singleton().GetActorByName(name);
        }
        public List<FilmDTO> GetFilmByActors(int id)
        {
            return DalSingleton.Singleton().GetFilmByActors(id);
        }
            public List<RealisateurDTO> GetDirectorById(int id)
        {
            return DalSingleton.Singleton().GetDirectorById(id);
        }
        public List<FilmDTO> GetFilmById(int id)
        {
            return DalSingleton.Singleton().GetFilmById(id);
        }
        public List<FilmDTO> GetFilmByName(string name)
        {
            return DalSingleton.Singleton().GetFilmByName(name);
        }
            public void SetTrailer(int id, string trailer)
        {
            DalSingleton.Singleton().SetTrailer(id, trailer);
        }
        public List<ActeurDTO> GetActor(int id)
        {
            return DalSingleton.Singleton().GetActor(id);
        }
    }
}
