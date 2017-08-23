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
    public partial class IzbrisiDob : Form
    {
        public IzbrisiDob()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Niste uneli podatke.");
                }
                else
                {
                    int rez;
                    if (!int.TryParse(textBox1.Text, out rez))
                    {
                        MessageBox.Show("Id dobavljača mora biti broj!");
                    }
                    else
                    {
                        cmd.CommandText = "Delete from Dobavljac where IdDob = @IdDob";
                        cmd.Parameters.AddWithValue("@IdDob", textBox1.Text);
                        cmd.Connection = konekcija;
                        konekcija.Open();
                        int obrisanRed = cmd.ExecuteNonQuery();
                        if (obrisanRed == 0)
                        {
                            MessageBox.Show("Dobavljač ciji je id: " + textBox1.Text + " ne postoji u bazi.");
                        }
                        else
                        {
                            MessageBox.Show("Proizvod ciji je id: " + textBox1.Text + " je obrisan iz baze.");
                        }
                    }
                }
                Dispose();
                konekcija.Close();
            }
        }
    }
}
