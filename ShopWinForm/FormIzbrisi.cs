using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ShopWinForm
{
    public partial class FormIzbrisi : Form
    {
        public FormIzbrisi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Niste uneli podatke.");
                    }
                    else
                    {
                        int rez;
                        if (!int.TryParse(textBox1.Text, out rez))
                        {
                            MessageBox.Show("Id proizvoda mora biti broj!");
                        }
                        else
                        {
                            cmd.CommandText = "Delete from Proizvod where IdProizvod = @idProizvod";
                            cmd.Parameters.AddWithValue("@idProizvod", textBox1.Text);
                            cmd.Connection = konekcija;
                            konekcija.Open();
                            int obrisanRed = cmd.ExecuteNonQuery();
                            if (obrisanRed == 0)
                            {
                                MessageBox.Show("Proizvod ciji je id: " + textBox1.Text + " ne postoji u bazi.");
                            }
                            else
                            {
                                MessageBox.Show("Proizvod ciji je id: " + textBox1.Text + " je obrisan iz baze.");
                            }
                        }                       
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Dispose();
                konekcija.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FormIzbrisi_Load(object sender, EventArgs e)
        {

        }
    }
}
