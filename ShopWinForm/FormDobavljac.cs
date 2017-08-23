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
    public partial class FormDobavljac : Form
    {
        public FormDobavljac()
        {
            InitializeComponent();
        }

        private void FormDobavljac_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrikazDob prDob = new PrikazDob();
            prDob.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnesiDob unDob = new UnesiDob();
            unDob.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzbrisiDob izbDob = new IzbrisiDob();
            izbDob.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IzmeniDob izmDob = new IzmeniDob();
            izmDob.ShowDialog();
        }
    }
}
