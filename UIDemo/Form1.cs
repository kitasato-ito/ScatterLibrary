﻿using GraphLibrary.Graphs.Plots;
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
        private ValuePlotModel plotModel = new ValuePlotModel();
        public Form1()
        {
            InitializeComponent();
            this.plotModel.SetXGrid(GridLineType.INWARD_SCALE, Color.Gray);
            this.plotModel.SetYGrid(GridLineType.INWARD_SCALE, Color.Gray);
        }

        private ScatterPlot line = new ScatterPlot();

        private void ShowGraphButton_Click(object sender, EventArgs e)
        {
            line.Add(new DataPoint(0, 2));
            line.Add(new DataPoint(1.5f, 3));
            line.Add(new DataPoint(4, 6));
            line.Add(new DataPoint(7, 2));
            line.Add(new DataPoint(9, 8));
            this.plotModel.Add(line);
            this.graphView1.GraphModel = this.plotModel;
            this.graphView1.InvalidateView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            line.Add(new DataPoint(3, 4));
            line.Add(new DataPoint(10, 4));
            this.graphView1.InvalidateView();
        }
    }
}
