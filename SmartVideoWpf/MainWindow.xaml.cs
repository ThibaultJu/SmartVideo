using FilmDTOLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
        private int indexFilm;
        private Boolean started = false;
        public MainWindow()
        {
            InitializeComponent();
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            this.WindowState = WindowState.Maximized;
            indexFilm = 0;
            FilmsViewModel fVM = new FilmsViewModel();
            int page,nbreFilms;
            if (!int.TryParse(NumPage.Content.ToString(),out page))
                Console.WriteLine("String could not be parsed.");
            String tmp=ComboBoxFilmsPages.Text;
             if(!int.TryParse(tmp, out nbreFilms))
                Console.WriteLine("String could not be parsed.");
            Console.WriteLine(page + " " + nbreFilms);

            dataGridFilms.ItemsSource = fVM.GetFilms(indexFilm , nbreFilms);
            dataGridFilms.SelectedIndex = 0;
            started = true;

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


        private void SelectFilmNumber(object sender, EventArgs e)
        {
            started = false;
            FilmsViewModel fVM = new FilmsViewModel();
            int page, nbreFilms;
            if (!int.TryParse(NumPage.Content.ToString(), out page))
                Console.WriteLine("String could not be parsed.");
            String tmp = ComboBoxFilmsPages.Text;
            if (!int.TryParse(tmp, out nbreFilms))
                Console.WriteLine("String could not be parsed.");
            page = indexFilm / nbreFilms;
            page++;
            NumPage.Content = page;
            dataGridFilms.ItemsSource = fVM.GetFilms(indexFilm, nbreFilms);
            dataGridFilms.SelectedIndex = 0;
            started = true;
        }

        private void ClickNextPage(object sender, RoutedEventArgs e)
        {
            started = false;
            FilmsViewModel fVM = new FilmsViewModel();
            int page, nbreFilms;
            if (!int.TryParse(NumPage.Content.ToString(), out page))
                Console.WriteLine("String could not be parsed.");
            String tmp = ComboBoxFilmsPages.Text;
            if (!int.TryParse(tmp, out nbreFilms))
                Console.WriteLine("String could not be parsed.");
            indexFilm = indexFilm + nbreFilms;
            page++;
            NumPage.Content = page;
            dataGridFilms.ItemsSource = fVM.GetFilms(indexFilm, nbreFilms);
            dataGridFilms.SelectedIndex = 0;
            started = true;
        }

        private void ClickPreviousPage(object sender, RoutedEventArgs e)
        {
            started = false;
            FilmsViewModel fVM = new FilmsViewModel();
            int page, nbreFilms;
            if (!int.TryParse(NumPage.Content.ToString(), out page))
                Console.WriteLine("String could not be parsed.");
            String tmp = ComboBoxFilmsPages.Text;
            if (!int.TryParse(tmp, out nbreFilms))
                Console.WriteLine("String could not be parsed.");
            if (indexFilm < nbreFilms)
            {
                indexFilm = 0;
                page = 1;
            }
            else
            {
                indexFilm = indexFilm - nbreFilms;
                page--;
            }
            NumPage.Content = page;
            dataGridFilms.ItemsSource = fVM.GetFilms(indexFilm, nbreFilms);
            dataGridFilms.SelectedIndex = 0;
            started = true;
        }

        private void idSelected(object sender, SelectionChangedEventArgs e)
        {
            if(started)
            {
                FilmsViewModel fVM = new FilmsViewModel();
                object item = dataGridFilms.SelectedItem;
                string ID = (dataGridFilms.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                DataGridGenre.ItemsSource = fVM.GetGenre(int.Parse(ID));
                DataGridActeur.ItemsSource = fVM.GetActorWithId(int.Parse(ID));
                DataGridRealisateur.ItemsSource = fVM.GetDirectorWithId(int.Parse(ID));
                loadImage((dataGridFilms.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                //Poster.Source = "http://image.tmdb.org/t/p/w185" + (dataGridFilms.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            }

        }
        public void loadImage(string path)
        {
            var image = new BitmapImage();
            int BytesToRead = 100;

            try
            {
                ServicePointManager.DefaultConnectionLimit = 10;
                Console.WriteLine("http://image.tmdb.org/t/p/w185" + path);
                WebRequest request = WebRequest.Create("http://image.tmdb.org/t/p/w185" + path);
                request.Timeout = 1000;
                Console.WriteLine(request.GetResponse());
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                BinaryReader reader = new BinaryReader(responseStream);
                MemoryStream memoryStream = new MemoryStream();

                byte[] bytebuffer = new byte[BytesToRead];
                int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

                while (bytesRead > 0)
                {
                    memoryStream.Write(bytebuffer, 0, bytesRead);
                    bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
                }
                
                image.BeginInit();
                memoryStream.Seek(0, SeekOrigin.Begin);

                image.StreamSource = memoryStream;
                image.EndInit();
                Poster.Source = image;
            }
            catch (WebException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
    }
}
