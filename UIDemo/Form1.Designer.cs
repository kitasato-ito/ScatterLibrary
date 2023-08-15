namespace UIDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            GraphLibrary.PlotModel plotModel2 = new GraphLibrary.PlotModel();
            this.ShowGraphButton = new System.Windows.Forms.Button();
            this.graphView1 = new GraphLibrary.GraphView();
            this.SuspendLayout();
            // 
            // ShowGraphButton
            // 
            this.ShowGraphButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ShowGraphButton.Location = new System.Drawing.Point(390, 383);
            this.ShowGraphButton.Name = "ShowGraphButton";
            this.ShowGraphButton.Size = new System.Drawing.Size(176, 55);
            this.ShowGraphButton.TabIndex = 1;
            this.ShowGraphButton.Text = "Update";
            this.ShowGraphButton.UseVisualStyleBackColor = false;
            this.ShowGraphButton.Click += new System.EventHandler(this.ShowGraphButton_Click);
            // 
            // graphView1
            // 
            this.graphView1.GraphModel = plotModel2;
            this.graphView1.Location = new System.Drawing.Point(55, 12);
            this.graphView1.Name = "graphView1";
            this.graphView1.Size = new System.Drawing.Size(567, 345);
            this.graphView1.TabIndex = 0;
            this.graphView1.Text = "graphView1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowGraphButton);
            this.Controls.Add(this.graphView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private GraphLibrary.GraphView graphView1;
        private System.Windows.Forms.Button ShowGraphButton;
    }
}

