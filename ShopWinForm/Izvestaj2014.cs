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
    public partial class Izvestaj2014 : Form
    {
        public Izvestaj2014()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Izvestaj2014_Load(object sender, EventArgs e)
        {
            this.chart1.Series["Prihod rsd"].Points.AddXY("1 kvartal", 200000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("1 kvartal", 190000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("2 kvartal", 205000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("2 kvartal", 190000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("3 kvartal", 180000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("3 kvartal", 190000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("4 kvartal", 210000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("4 kvartal", 190000);
        }
    }
}
