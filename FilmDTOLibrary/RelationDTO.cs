using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDTOLibrary
{
    public class RelationDTO
    {
        // <copyright file="RelationDTO" company="Haute Ecole de la Province de Liège">
            // Copyright (c) 2016 All Rights Reserved
            // <author>Cécile Moitroux</author>
            // </copyright>
        private int id;
        private int idfilm;
        private int idother;

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

        public int Idfilm
        {
            get
            {
                return idfilm;
            }

            set
            {
                idfilm = value;
            }
        }

        public int Idother
        {
            get
            {
                return idother;
            }

            set
            {
                idother = value;
            }
        }

        public RelationDTO(int _id, int _idfilm, int _idother)
        {
            Id = _id;
            Idfilm = _idfilm;
            Idother = _idother;
        }
    }
}
