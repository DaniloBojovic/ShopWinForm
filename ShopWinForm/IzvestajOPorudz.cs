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
    public partial class IzvestajOPorudz : Form
    {
        public IzvestajOPorudz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Select p.idProizvod as 'Id proizvoda',nazivProizvod as Naziv,cena,datum 'Datum porudžbine', kol Kolicina,d.IdDob 'ID dobavljaca',NazDob Dobavljac, Grad+', ' + Adresa as Adresa from Proizvod p,Porudzbina por, Dobavljac d where p.idProizvod = por.idProizvod and por.IdDob = d.IdDob and datum = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                    
                    cmd.Connection = konekcija;
                    konekcija.Open();
                    int rows = (int)cmd.ExecuteScalar();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    dataGridView1.Columns[1].Width = 200;
                    dataGridView1.Columns[7].Width = 200;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Nema podataka o narudžbinama za ovaj datum.");
                }
                konekcija.Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void PrikazIzvestaja_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}