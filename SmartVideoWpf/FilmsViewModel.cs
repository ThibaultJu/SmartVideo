using FilmDTOLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

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
        public FilmDTO[] GetFilmswithId(int id)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            return (service.GetFilmWithId(id));
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
        public BitmapImage loadImage(string path)
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
                return image;
                //Poster.Source = image;
            }
            catch (WebException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
