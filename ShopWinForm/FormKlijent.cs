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
    public partial class FormKlijent : Form
    {
        public FormKlijent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrikaziKlij prikazKlij = new PrikaziKlij();
            prikazKlij.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnesiKlij unosKlij = new UnesiKlij();
            unosKlij.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IzbriziKlij brisKlij = new IzbriziKlij();
            brisKlij.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IzmeniKlij izmenKlij = new IzmeniKlij();
            izmenKlij.ShowDialog();
        }
    }
}
