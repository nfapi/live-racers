namespace LiveRacersManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaDeResultados = new System.Windows.Forms.ListBox();
            this.posicionesTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.reporteTxt = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // listaDeResultados
            // 
            this.listaDeResultados.FormattingEnabled = true;
            this.listaDeResultados.ItemHeight = 15;
            this.listaDeResultados.Location = new System.Drawing.Point(10, 42);
            this.listaDeResultados.Name = "listaDeResultados";
            this.listaDeResultados.Size = new System.Drawing.Size(304, 364);
            this.listaDeResultados.TabIndex = 0;
            this.listaDeResultados.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChangedAsync);
            // 
            // posicionesTextBox
            // 
            this.posicionesTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.posicionesTextBox.Location = new System.Drawing.Point(320, 13);
            this.posicionesTextBox.Multiline = true;
            this.posicionesTextBox.Name = "posicionesTextBox";
            this.posicionesTextBox.ReadOnly = true;
            this.posicionesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.posicionesTextBox.Size = new System.Drawing.Size(248, 394);
            this.posicionesTextBox.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(625, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(241, 394);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.Location = new System.Drawing.Point(574, 13);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 25);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(232, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(46, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refresh";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // reporteTxt
            // 
            this.reporteTxt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reporteTxt.Location = new System.Drawing.Point(10, 449);
            this.reporteTxt.Multiline = true;
            this.reporteTxt.Name = "reporteTxt";
            this.reporteTxt.ReadOnly = true;
            this.reporteTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reporteTxt.Size = new System.Drawing.Size(558, 182);
            this.reporteTxt.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 420);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(558, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(877, 640);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.reporteTxt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.posicionesTextBox);
            this.Controls.Add(this.listaDeResultados);
            this.Name = "Form1";
            this.Text = "Live Racers Manager";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaDeResultados;
        private System.Windows.Forms.TextBox posicionesTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox reporteTxt;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

