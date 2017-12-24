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
    public partial class _Default : Page
    {
        AuthenticationControler aC;
        public List<FilmDTO> listFilms;
        public List<ActeurDTO> listActors;
        public List<ActeurDTO> listActorsMovie;
        private int index = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            listFilms = new List<FilmDTO>();
            aC = new AuthenticationControler();
            //aC.setStatistiques();
            if (Session["Log"] != null && Session["LogOK"] != null)
            {
                HtmlAnchor link = (HtmlAnchor)this.Master.FindControl("Log");
                link.InnerText = (String)Session["Log"];
                link.HRef = (String)Session["LogOK"];
            }
            if(Session["Index"] != null)
            {
                index = (int)Session["Index"];
            }
                
            listFilms = aC.LoadFilm(index, 5);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = (int.Parse(LabelPage.Text)) - 1;
            if (i < 1)
                i = 1;
            LabelPage.Text = i.ToString();
            LabelPagebis.Text = i.ToString();
            string var = DropDownList1.SelectedValue;
            int tmp = int.Parse(var);
            if ((index - tmp) >= 0)
                index = index - tmp;
            else
                index = 0;

            listFilms = aC.LoadFilm(index, tmp);
            Session["Index"] = index;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int i= (int.Parse(LabelPage.Text)) + 1;
            LabelPage.Text = i.ToString();
            LabelPagebis.Text = i.ToString();
            string var = DropDownList1.SelectedValue;
            int tmp = int.Parse(var);
            index = index + tmp;

            listFilms = aC.LoadFilm(index, tmp);
            Session["Index"] = index;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string var = DropDownList1.SelectedValue;
            int tmp = int.Parse(var);
            listFilms = aC.LoadFilm(index, tmp);
            DropDownList2.SelectedValue = var;
            int i = (index/tmp)+1;
            LabelPage.Text = i.ToString();
            LabelPagebis.Text = i.ToString();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string var = DropDownList2.SelectedValue;
            int tmp = int.Parse(var);
            listFilms = aC.LoadFilm(index, tmp);
            DropDownList1.SelectedValue = var;
        }

        protected void ButtonRechercheFilm_Click(object sender, EventArgs e)
        {
            listFilms = aC.RechercheFilmbyName(TextBoxIdFilm.Text);

        }
        protected void ButtonRechercheActeur_Click(object sender, EventArgs e)
        {
            listActors = aC.RechercheActorByName(TextBoxIdFilm.Text);
            listFilms = aC.RechercheFilmByActors(listActors);
        }
    }
}