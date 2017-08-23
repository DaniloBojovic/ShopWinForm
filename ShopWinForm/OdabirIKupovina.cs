using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ShopWinForm
{
    public partial class OdabirIKupovina : Form
    {
        int iznos = 0;
        public OdabirIKupovina()
        {
            InitializeComponent();
        }

        private void OdabirIKupovina_Load(object sender, EventArgs e)
        {
            textBox1.Text = 0.ToString();
            textBox2.Text = iznos.ToString();
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "dodaj";
                button.HeaderText = "";
                button.Text = "Dodaj";
                button.UseColumnTextForButtonValue = true; 
                this.dataGridView1.Columns.Add(button);
            }
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection konekcija = new SqlConnection(cs))
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand("Select nazivProizvod as Proizvod, cena from Proizvod", konekcija);
                SqlDataReader rdr = cmd.ExecuteReader();
                dataGridView1.DataSource = rdr;
                BindingSource source = new BindingSource();
                source.DataSource = rdr;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 150;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                richTextBox1.Text += row.Cells[1].Value.ToString() + "\n";
                textBox1.Text += row.Cells[2].Value.ToString();
                iznos += int.Parse(textBox1.Text);
                textBox2.Text = iznos.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Uspešno ste dodali proizvode u vašu korpu. Ukupan iznos za uplatu: " + iznos + " dinara.");
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li ste sigurni želite da izadjete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Dispose();
            }
            else
            { }
        }
    }
}
