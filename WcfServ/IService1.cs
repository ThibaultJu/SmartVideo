using FilmDTOLibrary;
using SmartVideoDBDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        // TODO: Add your service operations here
        [OperationContract]
        List<FilmDTO> GetFilms(int debut, int nb);

        [OperationContract]
        List<GenreDTO> GetGenreWithId(int id);

        [OperationContract]
        List<ActeurDTO> GetActorWithId(int id);

        [OperationContract]
        List<RealisateurDTO> GetDirectorWithId(int id);

        [OperationContract]
        List<FilmDTO> GetFilmWithId(int id);

        [OperationContract]
        void SetTrailer(int id, String trailer);

        [OperationContract]
        String Login(String E,String pass);

        [OperationContract]
        UtilisateursDTO findUser(string E);

        [OperationContract]
        void Update(UtilisateursDTO user);

    }




    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
