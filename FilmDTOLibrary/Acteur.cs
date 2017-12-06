using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDTOLibrary
{    
    public class ActeurDTO
    {
        // <copyright file="ActeurDTO" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>


        private int id;
        private string name;
        private string character;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Character
        {
            get
            {
                return character;
            }

            set
            {
                character = value;
            }
        }

        public ActeurDTO(int _id, string _name, string _character)
        {
            Id = _id;
            Name = _name;
            Character = _character;
        }

        public ActeurDTO(string text)
        {
            string[] acteurdetail,characterdetail;
            string tmp;
            Char[] delimiterChars = { '\u2024' };
            acteurdetail = text.Split(delimiterChars);
            Id = Int32.Parse(acteurdetail[0]);
            Name = acteurdetail[1];
            delimiterChars[0] = '/';
            tmp = acteurdetail[2];
            characterdetail = tmp.Split(delimiterChars);
            Character = characterdetail[0];
        }
    }
    public class Acteurs
    {
        // <copyright file="Acteurs" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>

        string[] acteurdetail;
        public Acteurs(string text)
        {
            Char[] delimiterChars = { '\u2016' };
            Acteurdetail = text.Split(delimiterChars);
        }

        public string[] Acteurdetail
        {
            get
            {
                return acteurdetail;
            }

            set
            {
                acteurdetail = value;
            }
        }
    }
}
