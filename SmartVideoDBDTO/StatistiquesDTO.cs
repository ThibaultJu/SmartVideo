using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDBDTO
{
    public class StatistiquesDTO
    {
        private int _idStats;
        private DateTime _date;
        private string _type;
        private int _nbRecherche;
        private int _idRequete;

        public int IdStats { get => _idStats; set => _idStats = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string Type { get => _type; set => _type = value; }
        public int NbRecherche { get => _nbRecherche; set => _nbRecherche = value; }
        public int IdRequete { get => _idRequete; set => _idRequete = value; }
        public StatistiquesDTO()
        {

        }
        public StatistiquesDTO(int idStats, DateTime date, string type, int nbRecheche, int idRequete)
        {
            IdStats = idStats;
            Date = date;
            Type = type;
            NbRecherche = nbRecheche;
            IdRequete = idRequete;
        }

    }
}
