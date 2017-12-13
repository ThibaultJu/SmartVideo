using FilmDTOLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartVideoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            this.WindowState = WindowState.Maximized;

            /*ServiceReference1.FilmDTO monFilm = new ServiceReference1.FilmDTO();

            monFilm = service.GetFilms(1, 1).First();*/
            FilmsViewModel fVM = new FilmsViewModel();
            dataGridFilms.ItemsSource = fVM.GetFilms(1,50);
            //dataGridFilms.Columns[0].Visibility = Visibility.Hidden;
                //service.GetFilms(1, 50);
        }

        private void dataGridFilms_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            switch ((string)e.Column.Header)
            {
                case "Acteurlist":
                    e.Cancel = true;
                    break;
                case "Genrelist":
                    e.Cancel = true;
                    break;
                case "Realisateurlist":
                    e.Cancel = true;
                    break;
                case "ExtensionData":
                    e.Cancel = true;
                    break;
                case "":
                    e.Cancel = true;
                    break;
            }
        }
    }
}
