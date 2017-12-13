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

        public List<GenreDTO> GetGenreWithId(int id)
        {
            return DalSingleton.Singleton().GetGenreWithId(id);
        }

        public List<ActeurDTO> GetActorWithId(int id)
        {
            return DalSingleton.Singleton().GetActorWithId(id);
        }

        public List<RealisateurDTO> GetDirectorWithId(int id)
        {
            return DalSingleton.Singleton().GetDirectorWithId(id);
        }
        public List<FilmDTO> GetFilmWithId(int id)
        {
            return DalSingleton.Singleton().GetFilmWithId(id);
        }

    }
}
