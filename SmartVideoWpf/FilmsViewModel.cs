using FilmDTOLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace SmartVideoWpf
{
    class FilmsViewModel
    {
        private FilmDTO _Data;

        public FilmsViewModel()
        {

        }

        public FilmDTO[] GetFilms(int debut, int fin)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            return(service.GetFilms(debut, fin));
        }
        public GenreDTO[] GetGenre(int id)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            return (service.GetGenreWithId(id));     
        }
        public ActeurDTO[] GetActorWithId(int id)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            return (service.GetActorWithId(id));
        }
        public RealisateurDTO[] GetDirectorWithId(int id)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            return (service.GetDirectorWithId(id));
        }
    }
}
