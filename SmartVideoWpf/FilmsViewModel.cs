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
        private ServiceReference1.FilmDTO _Data;

        public FilmsViewModel()
        {

        }

        public SmartVideoWpf.ServiceReference1.FilmDTO[] GetFilms(int debut, int fin)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            /*VideoWPF.dataGridFilms.ItemsSource = service.GetFilms(debut, fin);
            //VideoWPF.dataGridFilms.Columns[0].Visibility = Visibility.Hidden;*/
            return(service.GetFilms(debut, fin));
        }


    }
}
