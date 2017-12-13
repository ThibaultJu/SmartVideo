using FilmDTOLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DAL
{

    public class DalSingleton
    {
        public DalDataContext _context = null;
        private static DalSingleton _instance;

        public static DalSingleton Singleton()
        {
            return _instance ?? (_instance = new DalSingleton("PC-THIBAULT", "FilmDB"));
        }

        public DalSingleton(String servername, String DalSingletonname)
        {
            String connectionString = "Data Source = " + servername + " ; Initial Catalog =" + DalSingletonname + "; Integrated Security = True";

            try
            {
                _context = new DalDataContext(connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de connexion : " + e.Message);
            }



        }


        public List<FilmDTO> GetFilms(int debut, int nb)
        {
            var query = "SELECT * FROM Film;";
            try
            {
                List<FilmDTO> list = _context.ExecuteQuery<FilmDTO>(query).Skip(debut).Take(nb).Select(f => new FilmDTO
                {
                    Id = f.Id,
                    Title = f.Title,
                    Original_title = f.Original_title,
                    Runtime = f.Runtime,
                    Posterpath = f.Posterpath,
                    Trailer = f.Trailer
                }).ToList();
                return list;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " erreur d'affichage des résultats");
                return new List<FilmDTO>();
            }
        }

        public List<GenreDTO> GetGenreWithId(int id)
        {
            var query = "SELECT Genre.* FROM FilmGenre INNER JOIN Genre ON FilmGenre.id_genre = Genre.id WHERE FilmGenre.id_film = " + id + ";";
            try
            {
                var list = _context.ExecuteQuery<GenreDTO>(query).Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " erreur d'affichage des résultats");
                return new List<GenreDTO>();
            }
        }

        public List<ActeurDTO> GetActorWithId(int id)
        {
            var query = "SELECT Actor.* FROM FilmActor INNER JOIN Actor ON FilmActor.id_actor = Actor.id WHERE FilmActor.id_film = " + id + ";";
            try
            {
                var list = _context.ExecuteQuery<ActeurDTO>(query).Select(a => new ActeurDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Character = a.Character
                }).ToList();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " erreur d'affichage des résultats");
                return new List<ActeurDTO>();
            }
        }

        public List<RealisateurDTO> GetDirectorWithId(int id)
        {
            var query = "SELECT Realisateur.* FROM FilmRealisateur INNER JOIN Realisateur ON FilmRealisateur.id_realisateur = Realisateur.id WHERE FilmRealisateur.id_film = " + id + ";";
            try
            {
                var list = _context.ExecuteQuery<RealisateurDTO>(query).Select(g => new RealisateurDTO
                {
                    Id = g.Id,
                    Name = g.Name

                }).ToList();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " erreur d'affichage des résultats");
                return new List<RealisateurDTO>();
            }
        }
    }
}
