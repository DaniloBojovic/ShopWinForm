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
    public partial class RegistracijaForm : Form
    {
        public RegistracijaForm()
        {
            InitializeComponent();
        }

        private void RegistracijaForm_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"../../Images/reg.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Morate uneti sve podatke.");
                }
                else
                {
                    try
                    {
                        cmd.CommandText = "Insert into Kupac values (@Ime,@Prz,@Grad,@Adresa)";
                        cmd.Parameters.AddWithValue("@Ime", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Prz", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Grad", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Adresa", textBox4.Text);
                        cmd.Connection = konekcija;
                        konekcija.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = ("Insert into Registracija values (@UserName,@Pass,SYSDATETIME())");
                        cmd.Parameters.AddWithValue("@UserName", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = ("select max(IdKup) from Kupac");
                        int newID = (int)cmd.ExecuteScalar();
                        cmd.CommandText = ("select max(IdReg) from Registracija");
                        int newIdReg = (int)cmd.ExecuteScalar();
                        cmd.CommandText = ("Insert into registracijaKupac values(@newId,@newIdReg)");
                        cmd.Parameters.AddWithValue("@newId", newID);
                        cmd.Parameters.AddWithValue("@newIdReg", newIdReg);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspesno ste se registrovali! Vas id je " + newID + ".");
                        Dispose();
                    }catch(SqlException ex)
                    {
                        MessageBox.Show("Pasword nije odgovarajuć, pokušajte ponovo.");
                    }
                }
            }
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
