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
        private FilmsViewModel view;

        public MainWindow()
        {
            InitializeComponent();
            view = new FilmsViewModel();
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
                case "Posterpath":
                    e.Cancel = true;
                    break;
                case "Trailer":
                    e.Column.IsReadOnly = false;
                    break;
                case "Title":
                    e.Column.IsReadOnly = true;
                    break;
                case "Original_title":
                    e.Column.IsReadOnly = true;
                    break;
                case "Runtime":
                    e.Column.IsReadOnly = true;
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
                FilmDTO film = new FilmDTO();
                film = fVM.GetFilmswithId(int.Parse(ID)).First();
                Poster.Source = fVM.loadImage(film.Posterpath);
            }

        }

        private void BuTrailer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilmsViewModel fVM = new FilmsViewModel();
                object item = dataGridFilms.SelectedItem;
                string ID = (dataGridFilms.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                FilmDTO film = new FilmDTO();
                film = fVM.GetFilmswithId(int.Parse(ID)).First();
                System.Diagnostics.Process.Start(film.Trailer);
            }
            catch { }
        }

        private void TrailerUpdate(object sender, DataGridCellEditEndingEventArgs e)
        {
            FilmsViewModel fVM = new FilmsViewModel();
            object item = dataGridFilms.SelectedItem;
            string ID = (dataGridFilms.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            string str;
            TextBox t = e.EditingElement as TextBox;
            str = t.Text.ToString();
            Console.WriteLine(str);
            fVM.updateTrailer(int.Parse(ID), str);
        }

    }
}
