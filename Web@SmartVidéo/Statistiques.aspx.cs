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
    public partial class Statistiques : Page
    {
        public AuthenticationControler aC;
        public List<StatistiquesDTO> listStatistiques;
        public FilmDTO film;
        public ActeurDTO actor;
        protected void Page_Load(object sender, EventArgs e)
        {
            aC = new AuthenticationControler();
            listStatistiques = new List<StatistiquesDTO>();
            actor = new ActeurDTO();
            film = new FilmDTO();
            if (Session["Log"] != null && Session["LogOK"] != null)
            {
                HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                link.InnerText = (String)Session["Log"];
                link.HRef = (String)Session["LogOK"];
            }
            listStatistiques = aC.getStatistiques();
        }

    }
}