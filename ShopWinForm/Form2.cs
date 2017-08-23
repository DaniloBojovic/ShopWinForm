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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prikazi f3 = new Prikazi();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUnesi f4 = new FormUnesi();
            f4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormIzbrisi fIzbrisi = new FormIzbrisi();
            fIzbrisi.ShowDialog();
            fIzbrisi.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormIzmeni fIzmeni = new FormIzmeni();
            fIzmeni.ShowDialog();
        }
    }
}
