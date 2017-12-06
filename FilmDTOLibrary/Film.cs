using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDTOLibrary
{

    public class FilmDTO
    {
        // <copyright file="FilmDTO" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        private List<GenreDTO> genrelist;
        private List<RealisateurDTO> realisateurlist;
        private List<ActeurDTO> acteurlist;

        private int id;
        private string title;
        private string original_title;
        private int runtime;
        private string posterpath;
        private string trailer;

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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Original_title
        {
            get
            {
                return original_title;
            }

            set
            {
                original_title = value;
            }
        }

        public int Runtime
        {
            get
            {
                return runtime;
            }

            set
            {
                runtime = value;
            }
        }

        public string Posterpath
        {
            get
            {
                return posterpath;
            }

            set
            {
                posterpath = value;
            }
        }

        public List<GenreDTO> Genrelist
        {
            get
            {
                return genrelist;
            }

            set
            {
                genrelist = value;
            }
        }

        public List<RealisateurDTO> Realisateurlist
        {
            get
            {
                return realisateurlist;
            }

            set
            {
                realisateurlist = value;
            }
        }

        public List<ActeurDTO> Acteurlist
        {
            get
            {
                return acteurlist;
            }

            set
            {
                acteurlist = value;
            }
        }

        public string Trailer { get => trailer; set => trailer = value; }

        // Préparation de la classe pour recevoir les données
        public FilmDTO()
        {
            Genrelist = new List<GenreDTO>();
            Realisateurlist = new List<RealisateurDTO>();
            Acteurlist = new List<ActeurDTO>();
        }
    }

    public class FilmText
    {
        // <copyright file="FilmText" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        private string[] filmdetailwords;
        private string[] genres;        
        private string[] realisateurs;
        private string[] acteurs;

        private FilmDTO f;

        public FilmText()
        {
        }

        public FilmDTO DecodeFilmText(string filmtext)
        {
            FilmDTO f = new FilmDTO();
            Char[] delimiterChars = { '\u2023' };
            
           
            Filmdetailwords = filmtext.Split(delimiterChars);
            delimiterChars[0] = '\u2016';
            // Initialisation des champs de base du film
            f.Id = Int32.Parse(Filmdetailwords[0]);
            f.Title = Filmdetailwords[1];
            f.Original_title = Filmdetailwords[1];
            f.Runtime = Int32.Parse(Filmdetailwords[7]);
            f.Posterpath = Filmdetailwords[9];

            // Initialisation des champs détails du film
            if (Filmdetailwords.Length == 15)
            { 
                genres = Filmdetailwords[12].Split(delimiterChars);
                foreach (string s in genres)
                {
                    if (s.Length > 0)
                        f.Genrelist.Add(new GenreDTO(s));
                }
                realisateurs = Filmdetailwords[13].Split(delimiterChars);
                foreach (string s in realisateurs)
                {
                    if (s.Length > 0)
                        f.Realisateurlist.Add(new RealisateurDTO(s));
                }
                acteurs = Filmdetailwords[14].Split(delimiterChars);
                foreach (string s in acteurs)
                    if (s.Length > 0)
                        f.Acteurlist.Add(new ActeurDTO(s));
            }

            return f;
        }

        public string[] Filmdetailwords
        {
            get
            {
                return filmdetailwords;
            }

            set
            {
                filmdetailwords = value;
            }
        }
    }
}
