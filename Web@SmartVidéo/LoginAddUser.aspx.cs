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
    public partial class LoginAddUser : System.Web.UI.Page
    {
        AuthenticationControler aC;
        protected void Page_Load(object sender, EventArgs e)
        {
            aC = new AuthenticationControler();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            UtilisateursDTO user = new UtilisateursDTO();
            user.Carte = TextBoxCarte.Text;
            user.Email = TextBoxLogin.Text;
            user.Pseudo = TextBoxPseudo.Text;
            user.Password = Password1.Value.ToString();
            aC.InsertUser(user);
        }
    }
}