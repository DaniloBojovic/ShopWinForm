using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ShopWinForm
{
    public partial class Prikazi : Form
    {
        public Prikazi()
        {
            InitializeComponent();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection konekcija = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand
                ("Select idProizvod as 'ID Proizvoda', nazivProizvod as Naziv, cena as Cena from Proizvod", konekcija);
            konekcija.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = rdr;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[1].Width = 200;
            konekcija.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
