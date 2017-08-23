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
    public partial class Izvestaj2016 : Form
    {
        public Izvestaj2016()
        {
            InitializeComponent();
        }

        private void Izvestaj2016_Load(object sender, EventArgs e)
        {
            this.chart1.Series["Prihod rsd"].Points.AddXY("1 kvartal", 500000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("1 kvartal", 490000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("2 kvartal", 505000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("2 kvartal", 430000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("3 kvartal", 680000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("3 kvartal", 660000);

            this.chart1.Series["Prihod rsd"].Points.AddXY("4 kvartal", 680000);
            this.chart1.Series["Rashod rsd"].Points.AddXY("4 kvartal", 690000);
        }
    }
}
