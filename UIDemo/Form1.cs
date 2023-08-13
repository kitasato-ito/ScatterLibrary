using GraphLibrary.Graphs.Plots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphLibrary.Struct;

namespace UIDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowGraphButton_Click(object sender, EventArgs e)
        {
            var scatter = new ScatterPlot();
            scatter.Add(new DataPoint(0, 2));
            scatter.Add(new DataPoint(1, 3));
            scatter.Add(new DataPoint(4, 6));
            scatter.Add(new DataPoint(7, 2));
            scatter.Add(new DataPoint(9, 8));
            this.graphView1.GraphModel.Add(scatter);
            this.graphView1.InvalidateView();
        }
    }
}
