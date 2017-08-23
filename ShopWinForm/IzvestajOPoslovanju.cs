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
    public partial class IzvestajOPoslovanju : Form
    {
        public IzvestajOPoslovanju()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izvestaj2014 izv1 = new Izvestaj2014();
            izv1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Izvestaj2015 izv2 = new Izvestaj2015();
            izv2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Izvestaj2016 izv3 = new Izvestaj2016();
            izv3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
