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
    public partial class UnesiKlij : Form
    {
        public UnesiKlij()
        {
            InitializeComponent();
        }

        private void UnesiKlij_Load(object sender, EventArgs e)
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
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    {
                        MessageBox.Show("Morate uneti sve podatke.");
                    }
                    else
                    {
                        cmd.CommandText = "Insert into Kupac values (@Ime,@Prz,@Grad,@Adresa)";
                        cmd.Parameters.AddWithValue("@Ime", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Prz", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Grad", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Adresa", textBox5.Text);
                        cmd.Connection = konekcija;
                        konekcija.Open();
                        int unesenRed = cmd.ExecuteNonQuery();
                        cmd.CommandText = ("Insert into Registracija values (@UserName,@Pass,SYSDATETIME())");
                        cmd.Parameters.AddWithValue("@UserName", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Pass", textBox7.Text);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = ("select max(IdKup) from Kupac");
                        int newID = (int)cmd.ExecuteScalar();
                        cmd.CommandText = ("select max(IdReg) from Registracija");
                        int newIdReg = (int)cmd.ExecuteScalar();
                        cmd.CommandText = ("Insert into registracijaKupac values(@newId,@newIdReg)");
                        cmd.Parameters.AddWithValue("@newId", newID);
                        cmd.Parameters.AddWithValue("@newIdReg", newIdReg);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uneli ste novog kupca, njegov id je: " + newID);
                        //MessageBox.Show("Broj unesenih redova: " + unesenRed.ToString());
                        konekcija.Close();
                        Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);//"Dobavljac ciji je id: " + textBox1.Text + " vec postoji u bazi!");
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
