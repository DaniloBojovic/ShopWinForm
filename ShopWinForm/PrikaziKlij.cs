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
    public partial class PrikaziKlij : Form
    {
        public PrikaziKlij()
        {
            InitializeComponent();
        }

        private void PrikaziKlij_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection konekcija = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select IdKup as 'ID Kupca', Ime, Prz as Prezime, Grad, Adresa from Kupac", konekcija);
            konekcija.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = rdr;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[4].Width = 200;
            konekcija.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
