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
    public partial class PrikaziReg : Form
    {
        public PrikaziReg()
        {
            InitializeComponent();
        }

        private void PrikaziReg_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection konekcija = new SqlConnection(cs);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select IdKup from registracijaKupac";
                cmd.Connection = konekcija;
                konekcija.Open();
                int rows = (int)cmd.ExecuteScalar();
        
                cmd.CommandText = "select k.IdKup as 'Id Kupca',Ime,Prz as Prezime,Grad,Adresa,r.IdReg as 'Id registracije',Username,Pass as Password,datumReg as 'Datum registracije' from Kupac k, Registracija r, registracijaKupac rg where k.IdKup = rg.IdKup and rg.IdReg = r.IdReg";
                SqlDataReader rdr = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = rdr;
                dataGridView1.DataSource = source;
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("Nema podataka o registracijama.");
            }
            konekcija.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
