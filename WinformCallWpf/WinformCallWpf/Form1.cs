using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace WinformCallWpf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //userControl11.Values1 = new ChartValues<double> { 9, 6, -6, 3, -2, 6 };
            //userControl11.Values2 = new ChartValues<double> { 5, -3, 5, 7, -3, 9 };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //userControl11.Values1 = new ChartValues<double> { 3, 4, 6, 3, 2, 6 };
            //userControl11.Values2 = new ChartValues<double> { 5, 3, 5, 7, 3, 9 };
            //modifying the series collection will animate and update the chart
            var random = new Random(DateTime.Now.Millisecond);
            userControl11.SeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { random.Next(-10,10), random.Next(-10, 10), random.Next(-10, 10), random.Next(-10, 10) },
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 25,
                PointForeground = System.Windows.Media.Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            userControl11.SeriesCollection[3].Values.Add((double)random.Next(-10, 10));
        }
    }
}
