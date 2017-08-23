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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLog = new AdminLogin();
            adminLog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzborKorisnikForm izborF = new IzborKorisnikForm();
            izborF.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
