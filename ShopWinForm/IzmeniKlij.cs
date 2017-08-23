using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopWinForm
{
    public partial class IzmeniKlij : Form
    {
        public IzmeniKlij()
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
                    cmd.CommandText = "Update Kupac set Ime = @Ime, Prz = @Prz, Grad = @Grad, Adresa=@Adresa where IdKup = @IdKup";
                    cmd.Parameters.AddWithValue("@Ime", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Prz", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Grad", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Adresa", textBox5.Text);
                    cmd.Parameters.AddWithValue("@IdKup", textBox1.Text);
                    //cmd.CommandText = "Update Proizvod set nazivProizvod = '" + textBox2.Text + "', cena = '" +
                    //    textBox3.Text + "' where idProizvod = '" + textBox1.Text + "'";
                    cmd.Connection = konekcija;
                    konekcija.Open();
                    int izmenjenRedD = cmd.ExecuteNonQuery();

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    {
                        MessageBox.Show("Morate popuniti sva polja.");
                    }
                    else
                    {
                        if (izmenjenRedD == 0)
                        {
                            MessageBox.Show("Klijent ciji je id: " + textBox1.Text + " ne postoji u bazi.");
                        }
                        else
                        {
                            MessageBox.Show("Izmena klijenta ciji je id: " + textBox1.Text + " je izvrsena.");
                        }
                    }

                    Dispose();
                    konekcija.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
