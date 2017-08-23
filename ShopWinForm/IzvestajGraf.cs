using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopWinForm
{
    public partial class IzvestajGraf : Form
    {
        public IzvestajGraf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IzvestajOPorudz pi = new IzvestajOPorudz();
            pi.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IzvestajOreg regIzv = new IzvestajOreg();
            regIzv.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IzvestajOPoslovanju godIzv = new IzvestajOPoslovanju();
            godIzv.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
