namespace WindowsFormsApp6
{
    partial class frmShapesMovement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpShapesCheckBoxPnl = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.grpShapesCheckBoxPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpShapesCheckBoxPnl
            // 
            this.grpShapesCheckBoxPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpShapesCheckBoxPnl.Controls.Add(this.checkBox1);
            this.grpShapesCheckBoxPnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpShapesCheckBoxPnl.Location = new System.Drawing.Point(49, 29);
            this.grpShapesCheckBoxPnl.Name = "grpShapesCheckBoxPnl";
            this.grpShapesCheckBoxPnl.Size = new System.Drawing.Size(107, 349);
            this.grpShapesCheckBoxPnl.TabIndex = 0;
            this.grpShapesCheckBoxPnl.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmShapesMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 572);
            this.Controls.Add(this.grpShapesCheckBoxPnl);
            this.DoubleBuffered = true;
            this.Name = "frmShapesMovement";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmShapesMovement_Load);
            this.grpShapesCheckBoxPnl.ResumeLayout(false);
            this.grpShapesCheckBoxPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpShapesCheckBoxPnl;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

