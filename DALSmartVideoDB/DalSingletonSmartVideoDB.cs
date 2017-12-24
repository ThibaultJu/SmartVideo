using FilmDTOLibrary;
using SmartVideoDBDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALSmartVideoDB
{
    public class DalSingletonSmartVideoDB
    {
        public DalSmartVideoDBDataContext _context = null;
        private static DalSingletonSmartVideoDB _instance;

        public static DalSingletonSmartVideoDB Singleton()
        {
            return _instance ?? (_instance = new DalSingletonSmartVideoDB("PC-THIBAULT", "SmartVideoDB"));
        }

        public DalSingletonSmartVideoDB(String servername, String DalSingletonname)
        {
            String connectionString = "Data Source = " + servername + " ; Initial Catalog =" + DalSingletonname + "; Integrated Security = True";

            try
            {
                _context = new DalSmartVideoDBDataContext(connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de connexion : " + e.Message);
            }

        }


        public UtilisateursDTO findUser(string E)
        {
            var query = "SELECT * FROM Utilisateurs where Email = '" + E + "';";
            var user = _context.ExecuteQuery<UtilisateursDTO>(query).Select(f => new UtilisateursDTO
            {
                Email = f.Email,
                Pseudo = f.Pseudo,
                Password = f.Password,
                Carte = f.Carte
            }).ToList();
            if (user.Any())
            {
                UtilisateursDTO tmp = (UtilisateursDTO)user.First();
                return tmp;
            }
            else
                return null;
        }
        public string Login(string E, string pass)
        {

            var query = "SELECT * FROM Utilisateurs where Email = '" + E + "' AND Password = '" + pass + "';";
            var user = _context.ExecuteQuery<UtilisateursDTO>(query).Select(f => new UtilisateursDTO
            {
                Email = f.Email,
                Pseudo = f.Pseudo,
                Password = f.Password,
                Carte = f.Carte
            }).ToList();
            if (user.Any())
            {
                UtilisateursDTO tmp = (UtilisateursDTO)user.First();
                return tmp.Email;
            }
            else
                return null;
        }
        public void UpdateUser(UtilisateursDTO user)
        {
            var query = from f in _context.Utilisateurs where f.Email == user.Email select f;

            foreach (Utilisateur f in query)
            {
                f.Carte = user.Carte;
                f.Password = user.Password;
                f.Pseudo = user.Pseudo;
            }
            _context.SubmitChanges();
        }

        public Boolean InsertUser(UtilisateursDTO user)
        {
            Utilisateur usr = new Utilisateur();
            usr.Carte = user.Carte;
            usr.Email = user.Email;
            usr.Pseudo = user.Pseudo;
            usr.Password = user.Password;
            _context.Utilisateurs.InsertOnSubmit(usr);
            try
            {
                _context.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Boolean InsertHits(int id, string type)
        {
            DateTime DateTime = DateTime.Today;
            var query = from f in _context.Hits where f.idRequete == id && f.date == DateTime && f.type == type select f;
            int cpt = 0;
            foreach (Hit f in query)
            {
                f.nbRecherche = f.nbRecherche + 1;
                cpt++;
            }
            _context.SubmitChanges();
            if (cpt == 0)
            {
                Hit hit = new Hit();
                hit.idRequete = id;
                hit.type = type;
                hit.date = DateTime;
                hit.nbRecherche = 1;
                _context.Hits.InsertOnSubmit(hit);
                try
                {
                    _context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            return false;
        }
        public Boolean InsertLocation(int id, String user, int duree)
        {
            DateTime DateTime = DateTime.Today;
            var query = from f in _context.LocationsFilms where f.idFilm == id select f;
            int count = _context.LocationsFilms.Count();
            int cpt = 0;
            foreach (LocationsFilm f in query)
            {
                //pas ok car déja en cours de location
                cpt++;
                return false;

            }
            if (cpt == 0)
            {
                //ok
                LocationsFilm Loc = new LocationsFilm();
                Loc.idLocationsFilm = count + 1;
                Loc.idFilm = id;
                Loc.Utilisateur = user;
                Loc.DateDébut = DateTime;
                Loc.DateFin = DateTime.AddMonths(duree);
                _context.LocationsFilms.InsertOnSubmit(Loc);
                try
                {
                    _context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            return true;
        }

        public List<LocationDTO> getLocation(string username)
        {
            string query = "SELECT * from LocationsFilms WHERE Utilisateur = '" + username + "' ;";
            try
            {
                List<LocationDTO> list = _context.ExecuteQuery<LocationDTO>(query).Select(l => new LocationDTO
                {
                    Username = l.Username,
                    IdFilm = l.IdFilm,
                    DateDebut = l.DateDebut,
                    DateFin = l.DateFin
                }).ToList();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " impossible d'afficher les résultats.");
                return new List<LocationDTO>();
            }
        }

        public void setStatistiques(string type, DateTime date)
        {
            string query = "select TOP (3) * from Hits where type ='" + type + "' and date = '" + date.ToString("yyyy-MM-dd") + "'order by nbRecherche desc;";
            try
            {
                List<HitsDTO> list = _context.ExecuteQuery<HitsDTO>(query).Select(l => new HitsDTO
                {
                    IdHits = l.IdHits,
                    Date = l.Date,
                    IdRequete = l.IdRequete,
                    NbRecherche = l.NbRecherche,
                    Type = l.Type
                }).ToList();
                foreach (HitsDTO hit in list)
                {
                    //insert Stat
                    int count = _context.Statistiques.Count();
                    Statistique stat = new Statistique();
                    stat.idStatistiques = count + 1;
                    stat.idRequete = hit.IdRequete;
                    stat.date = hit.Date;
                    stat.nbRecherche = hit.NbRecherche;
                    stat.type = hit.Type;
                    _context.Statistiques.InsertOnSubmit(stat);
                    try
                    {
                        _context.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " impossible d'afficher les résultats.");
            }

        }
        public List<StatistiquesDTO> getStatistiques()
        {
            DateTime date = DateTime.Today;
            string query = "select* from Statistiques where date = '" + date.ToString("yyyy-MM-dd") + "'order by type, nbRecherche desc";
            try
            {
                List<StatistiquesDTO> list = _context.ExecuteQuery<StatistiquesDTO>(query).Select(l => new StatistiquesDTO
                {
                    IdStats = l.IdStats,
                    Date = l.Date,
                    Type = l.Type,
                    NbRecherche = l.NbRecherche,
                    IdRequete = l.IdRequete
                }).ToList();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " impossible d'afficher les résultats.");
                return new List<StatistiquesDTO>();
            }
        }
    }    
}
