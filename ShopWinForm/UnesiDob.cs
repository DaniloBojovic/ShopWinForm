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
    public partial class UnesiDob : Form
    {
        public UnesiDob()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UnesiDob_Load(object sender, EventArgs e)
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
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text.ToString() == "" || textBox4.Text.ToString() == "" || textBox5.Text.ToString() == "")
                    {
                        MessageBox.Show("Morate uneti sve podatke.");
                    }
                    else
                    {
                        int rezultat;
                        if (!int.TryParse(textBox1.Text, out rezultat))
                        {
                            MessageBox.Show("Id dobavljača mora biti broj!");
                        }
                        else
                        {
                            cmd.CommandText = "Insert into Dobavljac values (@IdDob,@NazDob,@Drzava,@Grad,@Adresa)";
                            cmd.Parameters.AddWithValue("@IdDob", textBox1.Text);
                            cmd.Parameters.AddWithValue("@NazDob", textBox2.Text);
                            cmd.Parameters.AddWithValue("@Drzava", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Grad", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Adresa", textBox5.Text);
                            cmd.Connection = konekcija;
                            konekcija.Open();
                            int unesenRed = cmd.ExecuteNonQuery();
                            MessageBox.Show("Broj unesenih redova: " + unesenRed.ToString());
                            konekcija.Close();
                            Dispose();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Dobavljac ciji je id: " + textBox1.Text + " vec postoji u bazi!");
                }

                Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
