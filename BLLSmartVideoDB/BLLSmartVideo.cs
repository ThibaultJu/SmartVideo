using DALSmartVideoDB;
using FilmDTOLibrary;
using SmartVideoDBDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSmartVideoDB
{
    public class BLLSmartVideo
    {
        public String Login(string E, string pass)
        {
            return DalSingletonSmartVideoDB.Singleton().Login(E, pass);
        }
        public UtilisateursDTO findUser(string E)
        {
            return DalSingletonSmartVideoDB.Singleton().findUser(E);
        }
        public void UpdateUser(UtilisateursDTO user)
        {
            DalSingletonSmartVideoDB.Singleton().UpdateUser(user);
        }
        public Boolean InsertUser(UtilisateursDTO user)
        {
            return DalSingletonSmartVideoDB.Singleton().InsertUser(user);
        }
        public Boolean InsertHits(int id, string type)
        {
            return DalSingletonSmartVideoDB.Singleton().InsertHits(id, type);
        }
        public Boolean InsertLocation(int id, String user, int duree)
        {
            return DalSingletonSmartVideoDB.Singleton().InsertLocation(id, user, duree);
        }
        public List<LocationDTO> getLocation(string username)
        {
            return DalSingletonSmartVideoDB.Singleton().getLocation(username);
        }
        public void setStatistiques(string type, DateTime date)
        {
            DalSingletonSmartVideoDB.Singleton().setStatistiques(type, date);
        }
        public List<StatistiquesDTO> getStatistiques()
        {
            return DalSingletonSmartVideoDB.Singleton().getStatistiques();
        }

    }
}
