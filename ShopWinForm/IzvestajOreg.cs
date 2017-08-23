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
    public partial class IzvestajOreg : Form
    {
        public IzvestajOreg()
        {
            InitializeComponent();
        }

        private void IzvestajOreg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Select k.IdKup as 'Id kupca',Ime,Prz Prezime,Grad+', '+Adresa Adresa,r.IdReg as 'Id registracije',UserName,Pass Password, datumReg as 'Datum registracije' from Kupac k, Registracija r, registracijaKupac rk where k.IdKup=rk.IdKup and rk.IdReg=r.IdReg and datumReg = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";

                    cmd.Connection = konekcija;
                    konekcija.Open();
                    int rows = (int)cmd.ExecuteScalar();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    dataGridView1.Columns[3].Width = 200;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Nema podataka o narudžbinama za ovaj datum.");
                }
                konekcija.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
