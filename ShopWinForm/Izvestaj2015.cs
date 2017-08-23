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
    public partial class Izvestaj2015 : Form
    {
        public Izvestaj2015()
        {
            InitializeComponent();
        }

        private void Izvestaj2015_Load(object sender, EventArgs e)
        {
            this.chart1.Series["Prihod rsd"].Points.AddXY("1 kvartal", 400000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("1 kvartal", 390000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("2 kvartal", 405000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("2 kvartal", 430000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("3 kvartal", 480000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("3 kvartal", 490000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("4 kvartal", 510000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("4 kvartal", 490000);
        }
    }
}
