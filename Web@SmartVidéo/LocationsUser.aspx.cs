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
    public partial class LocationsUser : Page
    {
        public List<LocationsFilm> listFilms;
        AuthenticationControler aC;

        protected void Page_Load(object sender, EventArgs e)
        {
            aC = new AuthenticationControler();
            if (Session["Log"] != null && Session["LogOK"] != null)
            {
                HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                link.InnerText = (String)Session["Log"];
                link.HRef = (String)Session["LogOK"];
            }
            listFilms = aC.GetLocByUser(Session["Log"].ToString());
        }
    }
}