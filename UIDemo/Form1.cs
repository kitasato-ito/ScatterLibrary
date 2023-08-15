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
using GraphLibrary;

namespace UIDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.graphView1.GraphModel.SetXGrid(GridLineType.DOTLINE, Color.Gray);
            this.graphView1.GraphModel.SetYGrid(GridLineType.DOTLINE, Color.Gray);
        }

        private void ShowGraphButton_Click(object sender, EventArgs e)
        {
            var scatter = new LinePlot();
            scatter.Add(new DataPoint(0, 2));
            scatter.Add(new DataPoint(1.5f, 3));
            scatter.Add(new DataPoint(4, 6));
            scatter.Add(new DataPoint(7, 2));
            scatter.Add(new DataPoint(9, 8));
            this.graphView1.GraphModel.Add(scatter);

            this.graphView1.InvalidateView();
        }
    }
}
