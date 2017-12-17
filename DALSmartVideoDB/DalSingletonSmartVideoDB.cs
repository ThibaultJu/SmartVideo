﻿using SmartVideoDBDTO;
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
            var query = "SELECT * FROM Utilisateurs where Email = '" + E +"';";
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
                return tmp.Pseudo;
            }
            else
                return null;
        }
        public void Update(UtilisateursDTO user)
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


    }
}
