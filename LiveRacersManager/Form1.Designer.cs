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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // listaDeResultados
            // 
            this.listaDeResultados.FormattingEnabled = true;
            this.listaDeResultados.ItemHeight = 15;
            this.listaDeResultados.Location = new System.Drawing.Point(10, 12);
            this.listaDeResultados.Name = "listaDeResultados";
            this.listaDeResultados.Size = new System.Drawing.Size(304, 394);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(877, 416);
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
    }
}

