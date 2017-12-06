using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDTOLibrary
{
    public class GenreDTO
    {
        // <copyright file="GenreDTO" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        private int _id;
        private string name;
        

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
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

        public GenreDTO(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
        public GenreDTO(string text)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = text.Split(delimiterChars);
            Id = Int32.Parse(genredetail[0]);
            Name = genredetail[1];
        }
    }

    class Genres
    {
        // <copyright file="Genres" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        string[] genredetail;
        public Genres(string text)
        {
            Char[] delimiterChars = { '\u2016' };
            Genredetail = text.Split(delimiterChars);
        }

        public string[] Genredetail
        {
            get
            {
                return genredetail;
            }

            set
            {
                genredetail = value;
            }
        }
    }
}
