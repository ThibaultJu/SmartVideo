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
    public partial class InfoUser : System.Web.UI.Page
    {
        AuthenticationControler aC;
        protected void Page_Load(object sender, EventArgs e)
        {
            aC = new AuthenticationControler();
            if (!IsPostBack)
            {
                if (Session["Log"] != null && Session["LogOK"] != null)
                {
                    HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                    link.InnerText = (String)Session["Log"];
                    link.HRef = (String)Session["LogOK"];
                }

                UtilisateursDTO user = aC.findUser((String)Session["Email"]);
                if (user != null)
                {
                    TextBoxEmail.Text = user.Email;
                    TextBoxEmail.ReadOnly = true;
                    TextBoxCarte.Text = user.Carte;
                    TextBoxPseudo.Text = user.Pseudo;
                    TextBoxPassword.Text = user.Password;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
            link.InnerText = "Login";
            link.HRef = "~/Login";
            Session["Log"] = "Login";
            Session["LogOK"] = "~/Login";
            Server.Transfer("Default.aspx", true);
        }

        protected void ButtonModif_Click(object sender, EventArgs e)
        {
            UtilisateursDTO user = new UtilisateursDTO();
            user.Email = TextBoxEmail.Text;
            user.Carte = TextBoxCarte.Text;
            user.Password = TextBoxPassword.Text;
            user.Pseudo = TextBoxPseudo.Text;            
            aC.ModifyUser(user);
        }
    }
}