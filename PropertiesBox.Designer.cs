
namespace Team19SKiaR12
{
    partial class PropertiesBox
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.Label();
            this.descripTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.colorComboBox = new System.Windows.Forms.Label();
            this.showShape = new System.Windows.Forms.CheckBox();
            this.strokeBox = new System.Windows.Forms.ComboBox();
            this.strokeStyle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.SaveBtn.Location = new System.Drawing.Point(137, 247);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(148, 43);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click_1);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.ForeColor = System.Drawing.Color.IndianRed;
            this.Description.Location = new System.Drawing.Point(44, 48);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(79, 17);
            this.Description.TabIndex = 1;
            this.Description.Text = "Description";
            // 
            // descripTextBox
            // 
            this.descripTextBox.Location = new System.Drawing.Point(164, 45);
            this.descripTextBox.Multiline = true;
            this.descripTextBox.Name = "descripTextBox";
            this.descripTextBox.Size = new System.Drawing.Size(121, 61);
            this.descripTextBox.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Black",
            "Green",
            "Purple",
            "Yellow"});
            this.comboBox1.Location = new System.Drawing.Point(164, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // colorComboBox
            // 
            this.colorComboBox.AutoSize = true;
            this.colorComboBox.ForeColor = System.Drawing.Color.IndianRed;
            this.colorComboBox.Location = new System.Drawing.Point(44, 135);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(41, 17);
            this.colorComboBox.TabIndex = 4;
            this.colorComboBox.Text = "Color";
            // 
            // showShape
            // 
            this.showShape.AutoSize = true;
            this.showShape.Checked = true;
            this.showShape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showShape.ForeColor = System.Drawing.Color.IndianRed;
            this.showShape.Location = new System.Drawing.Point(164, 220);
            this.showShape.Name = "showShape";
            this.showShape.Size = new System.Drawing.Size(116, 21);
            this.showShape.TabIndex = 5;
            this.showShape.Text = "Shape Visible";
            this.showShape.UseVisualStyleBackColor = true;
            // 
            // strokeBox
            // 
            this.strokeBox.FormattingEnabled = true;
            this.strokeBox.Items.AddRange(new object[] {
            "Stroke and Fill",
            "Stroke"});
            this.strokeBox.Location = new System.Drawing.Point(164, 168);
            this.strokeBox.Name = "strokeBox";
            this.strokeBox.Size = new System.Drawing.Size(121, 24);
            this.strokeBox.TabIndex = 6;
            // 
            // strokeStyle
            // 
            this.strokeStyle.AutoSize = true;
            this.strokeStyle.ForeColor = System.Drawing.Color.IndianRed;
            this.strokeStyle.Location = new System.Drawing.Point(44, 175);
            this.strokeStyle.Name = "strokeStyle";
            this.strokeStyle.Size = new System.Drawing.Size(84, 17);
            this.strokeStyle.TabIndex = 7;
            this.strokeStyle.Text = "Stroke Style";
            // 
            // PropertiesBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(460, 313);
            this.Controls.Add(this.strokeStyle);
            this.Controls.Add(this.strokeBox);
            this.Controls.Add(this.showShape);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.descripTextBox);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.SaveBtn);
            this.Name = "PropertiesBox";
            this.Text = "PropertiesBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertiesBox_FormClosing);
            this.Load += new System.EventHandler(this.PropertiesBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox descripTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label colorComboBox;
        private System.Windows.Forms.CheckBox showShape;
        private System.Windows.Forms.ComboBox strokeBox;
        private System.Windows.Forms.Label strokeStyle;
    }
}