using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public partial class Form1 : Form
    {
        DalDataContext Dal;
        public Form1()
        {
            InitializeComponent();
            Dal = new DalDataContext();
            //actorBindingSource.DataSource = Dal;
            //actorBindingSource.DataMember = "Actors";
            var query = from a in Dal.Actors where a.id == 2 select a;
            actorBindingSource.DataSource = query;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //actorBindingSource.DataMember = "Actors";
        }
    }
}
