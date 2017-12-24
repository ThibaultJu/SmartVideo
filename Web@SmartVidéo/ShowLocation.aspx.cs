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
    public partial class ShowLocation : Page
    {
        public AuthenticationControler aC;
        public List<LocationDTO> listLocations;
        public FilmDTO film;
        protected void Page_Load(object sender, EventArgs e)
        {
            aC = new AuthenticationControler();
            listLocations = new List<LocationDTO>();
            film = new FilmDTO();
            if (Session["Log"] != null && Session["LogOK"] != null)
            {
                HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                link.InnerText = (String)Session["Log"];
                link.HRef = (String)Session["LogOK"];
            }
            if(Session["Log"].Equals("Login"))
            {
                Server.Transfer("Default.aspx", true);
            }
            listLocations = aC.GetLocation((String)Session["Log"]);
        }

    }
}