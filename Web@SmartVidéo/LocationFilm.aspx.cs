using Web_SmartVidéo.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Web_SmartVidéo
{
    public partial class LocationFilm : Page
    {
        FilmDTO film;
        private AuthenticationControler aC;
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
            Label1.Text = film.Title;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int duree;
            bool result = int.TryParse(TextBoxDuree.Text,out duree);
            if (result)
            {
                //ok pour format
                if (duree > 0 && duree < 12)
                {
                    //ok pour durée
                    if(aC.InsertLocation(film.Id, (String)Session["Log"], duree))
                    {
                        Server.Transfer("Default.aspx", true);
                    }
                    else
                    {
                        if(Session["Log"] != null)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "Erreur: le film est toujours en période de location");
                            //Server.Transfer("Default.aspx", true);

                        }                       
                        else
                            Server.Transfer("Login.aspx", true);
                    }
                }
                else
                    TextBoxDuree.Text = "3";
            }
        }
    }
}