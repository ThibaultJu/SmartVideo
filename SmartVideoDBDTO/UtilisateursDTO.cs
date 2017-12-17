using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDBDTO
{
    public class UtilisateursDTO
    {
        private string _Email;

        private string _Pseudo;

        private string _Password;

        private string _Carte;

        public string Email { get => _Email; set => _Email = value; }
        public string Pseudo { get => _Pseudo; set => _Pseudo = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Carte { get => _Carte; set => _Carte = value; }

        public UtilisateursDTO()
        {

        }

        public UtilisateursDTO(string email, string pseudo, string password, string carte)
        {
            _Email = email;
            _Pseudo = pseudo;
            _Password = password;
            _Carte = carte;
        }
    }
}
