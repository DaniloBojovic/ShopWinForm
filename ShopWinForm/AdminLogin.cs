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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
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
                    cmd.CommandText = ("Select UserName,Password from Admin where UserName=@Username and Password=@Password");
                    cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    cmd.Connection = konekcija;
                    konekcija.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows == true)
                    {
                        MessageBox.Show("Uspešno ste se ulogovali.");
                        Glavna glavna = new Glavna();
                        glavna.ShowDialog();
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Proverite username i password ponovo!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                catch (Exception ex)
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

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            pictureBox1.ImageLocation = @"../../Images/logAdmin.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
