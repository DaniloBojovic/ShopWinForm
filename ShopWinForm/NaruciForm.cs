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
    public partial class NaruciForm : Form
    {
        public NaruciForm()
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
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text.ToString() == "")
                    {
                        MessageBox.Show("Morate uneti sve podatke.");
                    }
                    else
                    {
                        cmd.CommandText = "Insert into Porudzbina values (@idProizvod,@IdDob,SYSDATETIME(),@kol)";
                        cmd.Parameters.AddWithValue("@idProizvod", textBox1.Text);
                        cmd.Parameters.AddWithValue("@IdDob", textBox2.Text);
                        cmd.Parameters.AddWithValue("@kol", textBox3.Text);
                        //cmd.CommandText = "Insert into Proizvod values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "');";
                        cmd.Connection = konekcija;
                        konekcija.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Napravili ste novu porudzbinu.");
                        konekcija.Close();
                        textBox1.Clear();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Podaci nisu validni, unesite podatke koji vec postoje u bazi.");
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
