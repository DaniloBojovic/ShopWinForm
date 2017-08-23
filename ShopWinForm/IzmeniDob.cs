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
    public partial class IzmeniDob : Form
    {
        public IzmeniDob()
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
                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    {
                        MessageBox.Show("Morate popuniti sva polja.");
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
                            cmd.CommandText = "Update Dobavljac set NazDob = @NazDob, Drzava = @Drzava, Grad = @Grad, Adresa=@Adresa where IdDob = @IdDob";
                            cmd.Parameters.AddWithValue("@NazDob", textBox2.Text);
                            cmd.Parameters.AddWithValue("@Drzava", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Grad", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Adresa", textBox5.Text);
                            cmd.Parameters.AddWithValue("@IdDob", textBox1.Text);
                            cmd.Connection = konekcija;
                            konekcija.Open();
                            int izmenjenRedD = cmd.ExecuteNonQuery();
                            if (izmenjenRedD == 0)
                            {
                                MessageBox.Show("Dobavljac ciji je id: " + textBox1.Text + " ne postoji u bazi.");
                            }
                            else
                            {
                                MessageBox.Show("Izmena dobavljaca ciji je id: " + textBox1.Text + " je izvrsena.");
                            }
                        }
                    }
                    konekcija.Close();
                    Dispose();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Id dobavljaca ne postoji u bazi");
                }
            }
        }
    }
}
