using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ServiceRequest newRequest = new ServiceRequest();
            //newRequest.MusteriID = AuthenticationManager.CurrentUser.Kullanici
        }

        private void yeniÜrünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 gecis = new Form2();
            gecis.Show();
            this.Hide();
        }

        private void güncelÜrünlerListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuncelUrun gecis = new GuncelUrun();
            gecis.Show();
            this.Hide();
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
