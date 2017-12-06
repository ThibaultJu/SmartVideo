using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDTOLibrary
{
    public class RealisateurDTO
    {
        // <copyright file="RealisateurDTO" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        private int id;
        private string name;

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
        public RealisateurDTO()
        {
        }
        public RealisateurDTO(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public RealisateurDTO(string text)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = text.Split(delimiterChars);
            Id = Int32.Parse(genredetail[0]);
            Name = genredetail[1];
        }
    }
    public class Realisateurs
    {
        // <copyright file="Realisateurs" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        string[] realisateurdetail;
        public Realisateurs(string text)
        {
            Char[] delimiterChars = { '\u2016' };
            Realisateurdetail = text.Split(delimiterChars);
        }

        public string[] Realisateurdetail
        {
            get
            {
                return realisateurdetail;
            }

            set
            {
                realisateurdetail = value;
            }
        }
    }
}
