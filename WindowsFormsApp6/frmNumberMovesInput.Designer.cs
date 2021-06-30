namespace WindowsFormsApp6
{
    partial class frmNumberMovesInput
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtNumberOfMoves = new System.Windows.Forms.TextBox();
            this.lblMassage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(85, 60);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 36);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm and Close";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtNumberOfMoves
            // 
            this.txtNumberOfMoves.Location = new System.Drawing.Point(222, 22);
            this.txtNumberOfMoves.MaxLength = 2;
            this.txtNumberOfMoves.Name = "txtNumberOfMoves";
            this.txtNumberOfMoves.Size = new System.Drawing.Size(39, 20);
            this.txtNumberOfMoves.TabIndex = 1;
            this.txtNumberOfMoves.TextChanged += new System.EventHandler(this.txtNumberOfMoves_TextChanged);
            // 
            // lblMassage
            // 
            this.lblMassage.AutoSize = true;
            this.lblMassage.Location = new System.Drawing.Point(27, 25);
            this.lblMassage.Name = "lblMassage";
            this.lblMassage.Size = new System.Drawing.Size(188, 13);
            this.lblMassage.TabIndex = 2;
            this.lblMassage.Text = "Please enter nember of moves to save";
            // 
            // frmNumberMovesInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 119);
            this.Controls.Add(this.lblMassage);
            this.Controls.Add(this.txtNumberOfMoves);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNumberMovesInput";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNumberMovesInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtNumberOfMoves;
        private System.Windows.Forms.Label lblMassage;
    }
}