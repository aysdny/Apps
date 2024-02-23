using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Application
{
    public partial class GuncelUrun : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;

        public GuncelUrun()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=URUN004;Initial Catalog=appdb;Integrated Security=True");
        }

        private void GuncelUrunListesi_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            try
            {
                con.Open();
                string sorgu = "SELECT * FROM UrunTablosu"; // UrunTablosu'nu kendi tablonuzla değiştirin
                da = new SqlDataAdapter(sorgu, con);
                dt = new DataTable();
                da.Fill(dt);

                // DataGridView kontrolüne veriyi bind etme
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // GuncelUrun_Load metodunu güncelledik, artık NotImplementedException hatası almazsınız.
        private void yeniÜrünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 gecis = new Form2();
            gecis.Show();
            this.Hide();
        }

        private void güncelÜrünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuncelUrun gecis = new GuncelUrun();
            gecis.Show();
            this.Hide();
        }
    }
}

