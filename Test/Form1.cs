using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*BLLClass filmBLL;
            filmBLL = new BLLClass();
            dataGridView1.DataSource = filmBLL.GetActorWithId(122);*/

            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            dataGridView1.DataSource = service.GetFilms(1, 10);

           // ServiceReference1.Service1Client = new ServiceReference1.Service1Client();


        }
    }
}
