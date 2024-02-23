using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string model = txtModel.Text;
                string marka = txtBrand.Text;
                string tur = txtType.Text;
                string seriNumarasi = txtSerialNumber.Text;

                // Stok Adedi'nin doğru bir şekilde sayıya çevrilip çevrilemediğini kontrol etmek için int.TryParse kullanalım.
                if (int.TryParse(txtStockCount.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int stokAdedi))
                {
                    using (SqlConnection connection = new SqlConnection("Data Source = URUN004; Initial Catalog=appdb; Integrated Security= True"))
                    {
                        connection.Open();

                        string query = "INSERT INTO Urun (model, marka, tur, seri_numarasi, stok_adedi) VALUES (@Model, @Marka, @Tur, @SeriNumarasi, @StokAdedi)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Model", model);
                            command.Parameters.AddWithValue("@Marka", marka);
                            command.Parameters.AddWithValue("@Tur", tur);
                            command.Parameters.AddWithValue("@SeriNumarasi", seriNumarasi);
                            command.Parameters.AddWithValue("@StokAdedi", stokAdedi);

                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Ürün başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Stok Adedi geçerli bir sayı değil", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void güncelÜrünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuncelUrun gecis = new GuncelUrun();
            gecis.Show();
            this.Hide();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 gecis = new Form2();
            gecis.Show();
            this.Hide();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
        }
    }
}