
namespace Team19SKiaR12
{
    partial class Import
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
            this.pathLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.pathLabel.Location = new System.Drawing.Point(14, 47);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(85, 17);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "Folder Path:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 22);
            this.textBox1.TabIndex = 2;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(411, 173);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pathLabel);
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}