using Web_SmartVidéo.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web_SmartVidéo
{
    public partial class DetailsF : Page
    {
        public FilmDTO film;
        AuthenticationControler aC;
        protected void Page_Load(object sender, EventArgs e)
        {
            aC = new AuthenticationControler();
            int id =int.Parse(Request.QueryString["titre"]);
            if (Session["Log"] != null && Session["LogOK"] != null)
            {
                HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                link.InnerText = (String)Session["Log"];
                link.HRef = (String)Session["LogOK"];
            }
            film = aC.GetFilm(id);
        }

        protected void ButtonTrailer_Click(object sender, EventArgs e)
        {
            if(film.Trailer != null)
            {
                System.Diagnostics.Process.Start(film.Trailer);
            }
        }

        protected void ButtonLocationFilm_Click(object sender, EventArgs e)
        {
            Server.Transfer("LocationFilm.aspx?titre=" + int.Parse(Request.QueryString["titre"]), true);
        }
    }
}