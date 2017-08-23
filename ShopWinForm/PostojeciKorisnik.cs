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
    public partial class PostojeciKorisnik : Form
    {
        public PostojeciKorisnik()
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
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ("Select UserName,Pass from Registracija where UserName=@Username and Pass=@Pass");
                    cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Pass", textBox2.Text);
                    cmd.Connection = konekcija;
                    konekcija.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows == true)
                    {                                                
                        MessageBox.Show("Uspešno ste se ulogovali.");
                        Dispose();
                        OdabirIKupovina ok = new OdabirIKupovina();
                        ok.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Proverite username i password ponovo!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool proveri = checkBox1.Checked;
            switch (proveri)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PostojeciKorisnik_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            pictureBox1.ImageLocation = @"C:\Users\igor\Desktop\BazaProjekatUvod\log.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
