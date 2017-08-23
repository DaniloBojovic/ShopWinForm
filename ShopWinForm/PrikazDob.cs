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
    public partial class PrikazDob : Form
    {
        public PrikazDob()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrikazDob_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection konekcija = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select IdDob as 'ID dobavljača', NazDob 'Naziv', Drzava as Država, Grad, Adresa  from Dobavljac", konekcija);
            konekcija.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = rdr;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[4].Width = 200;
            konekcija.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
