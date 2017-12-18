using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Web_SmartVidéo.ServiceReference1;

namespace Web_SmartVidéo
{
    public partial class Details : Page
    {
        AuthenticationControler aC;
        public List<FilmDTO> listFilms;
        public List<ActeurDTO> listActors;
        public List<ActeurDTO> listActorsMovie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                listFilms = new List<FilmDTO>();
                aC = new AuthenticationControler();
                if (Session["Log"] != null && Session["LogOK"] != null)
                {
                    HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                    link.InnerText = (String)Session["Log"];
                    link.HRef = (String)Session["LogOK"];
                }
                FilmDTO[] films = aC.LoadFilm(0, 5);
                listFilms = films.ToList();
            }

        }
        
    }
}