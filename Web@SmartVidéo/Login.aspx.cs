using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web_SmartVidéo
{
    public partial class Login : System.Web.UI.Page
    {
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = aC.Login(TextBox1.Text, Password1.Value.ToString());
            if (user != null)
            {
                HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                link.InnerText = user;
                link.HRef = "~/InfoUser";
                Session["Log"]= user;
                Session["LogOK"] = "~/InfoUser";
                Session["Email"] = TextBox1.Text;
                Server.Transfer("Default.aspx", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("LoginAddUser.aspx", true);
        }
    }
}