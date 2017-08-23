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
    public partial class FormIzmeni : Form
    {
        public FormIzmeni()
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
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Morate popuniti sva polja.");
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
                            cmd.CommandText = "Update Proizvod set nazivProizvod = @nazivProizvod, cena = @cena where idProizvod = @idProizvod";
                            cmd.Parameters.AddWithValue("@nazivProizvod", textBox2.Text);
                            cmd.Parameters.AddWithValue("@cena", textBox3.Text);
                            cmd.Parameters.AddWithValue("@idProizvod", textBox1.Text);
                            cmd.Connection = konekcija;
                            konekcija.Open();
                            int izmenjenRedD = cmd.ExecuteNonQuery();
                            if (izmenjenRedD == 0)
                            {
                                MessageBox.Show("Proizvod ciji je id: " + textBox1.Text + " ne postoji u bazi.");
                            }
                            else
                            {
                                MessageBox.Show("Izmena proizvoda ciji je id: " + textBox1.Text + " je izvrsena.");
                            }
                        }
                    }
                    Dispose();
                    konekcija.Close();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show("Id proizvoda ne postoji u bazi");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
