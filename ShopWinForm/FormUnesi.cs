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
    public partial class FormUnesi : Form
    {
        public FormUnesi()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text.ToString()== "")
                    {
                        MessageBox.Show("Morate uneti sve podatke.");
                    }
                    else
                    {
                        int rezultat;
                        if (!int.TryParse(textBox1.Text, out rezultat))
                        {
                            MessageBox.Show("Id proizvoda mora biti broj!");
                        }
                        else
                        {
                            cmd.CommandText = "Insert into Proizvod values (@idProizvod,@nazivProizvod,@cena)";
                            cmd.Parameters.AddWithValue("@idProizvod", textBox1.Text);
                            cmd.Parameters.AddWithValue("@nazivProizvod", textBox2.Text);
                            cmd.Parameters.AddWithValue("@cena", textBox3.Text);
                            cmd.Connection = konekcija;
                            konekcija.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Uneli ste novi proizvod ciji je id: " + textBox1.Text);
                            konekcija.Close();
                            textBox1.Clear();
                        }
                    }
                }                
                catch (SqlException ex)
                {
                    MessageBox.Show("Proizvod ciji je id: " + textBox1.Text + " vec postoji u bazi!");
                }

                Dispose();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
