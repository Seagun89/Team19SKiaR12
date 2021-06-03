
namespace Team19SKiaR12
{
    partial class MainAPP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAPP));
            this.skControl1 = new SkiaSharp.Views.Desktop.SKControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShapesBtn = new System.Windows.Forms.Button();
            this.TriBtn = new System.Windows.Forms.Button();
            this.CircleBtn = new System.Windows.Forms.Button();
            this.RectangleBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.ToolsBtn = new System.Windows.Forms.Button();
            this.aboutBoxBtn = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.diamondBtn = new System.Windows.Forms.Button();
            this.import_btn = new System.Windows.Forms.Button();
            this.connector_radio = new System.Windows.Forms.RadioButton();
            this.pointer_radio = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Help_Btn = new System.Windows.Forms.Button();
            this.TextBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LineBtnPic = new System.Windows.Forms.PictureBox();
            this.CircleBtnPic = new System.Windows.Forms.PictureBox();
            this.connections = new System.Windows.Forms.Label();
            this.connectionType = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineBtnPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircleBtnPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // skControl1
            // 
            this.skControl1.AllowDrop = true;
            this.skControl1.BackColor = System.Drawing.Color.LightGray;
            this.skControl1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.skControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skControl1.Location = new System.Drawing.Point(0, 0);
            this.skControl1.Name = "skControl1";
            this.skControl1.Size = new System.Drawing.Size(1200, 864);
            this.skControl1.TabIndex = 0;
            this.skControl1.Text = "skControl1";
            this.skControl1.PaintSurface += new System.EventHandler<SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs>(this.skControl1_PaintSurface);
            this.skControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.skControl1_DragDrop);
            this.skControl1.DragOver += new System.Windows.Forms.DragEventHandler(this.skControl1_DragOver);
            this.skControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.skControl1_MouseDoubleClick);
            this.skControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.skControl1_MouseDown);
            this.skControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.skControl1_MouseMove);
            this.skControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.skControl1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ShapesBtn
            // 
            this.ShapesBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ShapesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShapesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapesBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ShapesBtn.Location = new System.Drawing.Point(0, 109);
            this.ShapesBtn.Name = "ShapesBtn";
            this.ShapesBtn.Size = new System.Drawing.Size(190, 64);
            this.ShapesBtn.TabIndex = 1;
            this.ShapesBtn.Text = "Shapes";
            this.ShapesBtn.UseVisualStyleBackColor = false;
            // 
            // TriBtn
            // 
            this.TriBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TriBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TriBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.TriBtn.Location = new System.Drawing.Point(0, 285);
            this.TriBtn.Name = "TriBtn";
            this.TriBtn.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.TriBtn.Size = new System.Drawing.Size(190, 61);
            this.TriBtn.TabIndex = 4;
            this.TriBtn.Text = "Triangle";
            this.TriBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TriBtn.UseVisualStyleBackColor = false;
            this.TriBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TriBtn_MouseDown);
            // 
            // CircleBtn
            // 
            this.CircleBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CircleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CircleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.CircleBtn.Location = new System.Drawing.Point(0, 169);
            this.CircleBtn.Name = "CircleBtn";
            this.CircleBtn.Padding = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.CircleBtn.Size = new System.Drawing.Size(190, 63);
            this.CircleBtn.TabIndex = 5;
            this.CircleBtn.Text = "Circle";
            this.CircleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CircleBtn.UseVisualStyleBackColor = false;
            this.CircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseDown);
            // 
            // RectangleBtn
            // 
            this.RectangleBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RectangleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RectangleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RectangleBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.RectangleBtn.Location = new System.Drawing.Point(0, 228);
            this.RectangleBtn.Name = "RectangleBtn";
            this.RectangleBtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.RectangleBtn.Size = new System.Drawing.Size(190, 63);
            this.RectangleBtn.TabIndex = 7;
            this.RectangleBtn.Text = "Rectangle";
            this.RectangleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RectangleBtn.UseVisualStyleBackColor = false;
            this.RectangleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RectangleBtn_MouseDown);
            // 
            // ExportBtn
            // 
            this.ExportBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ExportBtn.Location = new System.Drawing.Point(0, 695);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(190, 54);
            this.ExportBtn.TabIndex = 16;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = false;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // ToolsBtn
            // 
            this.ToolsBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ToolsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolsBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ToolsBtn.Location = new System.Drawing.Point(0, 452);
            this.ToolsBtn.Name = "ToolsBtn";
            this.ToolsBtn.Size = new System.Drawing.Size(190, 59);
            this.ToolsBtn.TabIndex = 18;
            this.ToolsBtn.Text = "Tools\r\n";
            this.ToolsBtn.UseVisualStyleBackColor = false;
            // 
            // aboutBoxBtn
            // 
            this.aboutBoxBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.aboutBoxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBoxBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBoxBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.aboutBoxBtn.Location = new System.Drawing.Point(0, 798);
            this.aboutBoxBtn.Name = "aboutBoxBtn";
            this.aboutBoxBtn.Size = new System.Drawing.Size(190, 54);
            this.aboutBoxBtn.TabIndex = 20;
            this.aboutBoxBtn.Text = "About";
            this.aboutBoxBtn.UseVisualStyleBackColor = false;
            this.aboutBoxBtn.Click += new System.EventHandler(this.aboutBoxBtn_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelMenu.Controls.Add(this.pictureBox4);
            this.panelMenu.Controls.Add(this.diamondBtn);
            this.panelMenu.Controls.Add(this.import_btn);
            this.panelMenu.Controls.Add(this.connector_radio);
            this.panelMenu.Controls.Add(this.pointer_radio);
            this.panelMenu.Controls.Add(this.pictureBox3);
            this.panelMenu.Controls.Add(this.Help_Btn);
            this.panelMenu.Controls.Add(this.ToolsBtn);
            this.panelMenu.Controls.Add(this.TextBtn);
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Controls.Add(this.LineBtnPic);
            this.panelMenu.Controls.Add(this.TriBtn);
            this.panelMenu.Controls.Add(this.CircleBtnPic);
            this.panelMenu.Controls.Add(this.RectangleBtn);
            this.panelMenu.Controls.Add(this.CircleBtn);
            this.panelMenu.Controls.Add(this.connections);
            this.panelMenu.Controls.Add(this.connectionType);
            this.panelMenu.Controls.Add(this.ExportBtn);
            this.panelMenu.Controls.Add(this.aboutBoxBtn);
            this.panelMenu.Controls.Add(this.ShapesBtn);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.Color.IndianRed;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(190, 864);
            this.panelMenu.TabIndex = 1;
            // 
            // diamondBtn
            // 
            this.diamondBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.diamondBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.diamondBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diamondBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.diamondBtn.Location = new System.Drawing.Point(0, 397);
            this.diamondBtn.Name = "diamondBtn";
            this.diamondBtn.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.diamondBtn.Size = new System.Drawing.Size(190, 59);
            this.diamondBtn.TabIndex = 26;
            this.diamondBtn.Text = "Diamond";
            this.diamondBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diamondBtn.UseVisualStyleBackColor = false;
            this.diamondBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.diamond_MouseDown);
            // 
            // import_btn
            // 
            this.import_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.import_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import_btn.ForeColor = System.Drawing.Color.IndianRed;
            this.import_btn.Location = new System.Drawing.Point(0, 642);
            this.import_btn.Name = "import_btn";
            this.import_btn.Size = new System.Drawing.Size(190, 54);
            this.import_btn.TabIndex = 25;
            this.import_btn.Text = "Import";
            this.import_btn.UseVisualStyleBackColor = false;
            this.import_btn.Click += new System.EventHandler(this.import_btn_Click);
            // 
            // connector_radio
            // 
            this.connector_radio.AutoSize = true;
            this.connector_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connector_radio.Location = new System.Drawing.Point(35, 544);
            this.connector_radio.Name = "connector_radio";
            this.connector_radio.Size = new System.Drawing.Size(140, 21);
            this.connector_radio.TabIndex = 24;
            this.connector_radio.TabStop = true;
            this.connector_radio.Text = "Connector Tool";
            this.connector_radio.UseVisualStyleBackColor = true;
            this.connector_radio.CheckedChanged += new System.EventHandler(this.connector_radio_CheckedChanged);
            this.connector_radio.Click += new System.EventHandler(this.connector_radio_Click);
            // 
            // pointer_radio
            // 
            this.pointer_radio.AutoSize = true;
            this.pointer_radio.Checked = true;
            this.pointer_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointer_radio.Location = new System.Drawing.Point(35, 517);
            this.pointer_radio.Name = "pointer_radio";
            this.pointer_radio.Size = new System.Drawing.Size(118, 21);
            this.pointer_radio.TabIndex = 23;
            this.pointer_radio.TabStop = true;
            this.pointer_radio.Text = "Pointer Tool";
            this.pointer_radio.UseVisualStyleBackColor = true;
            this.pointer_radio.CheckedChanged += new System.EventHandler(this.pointer_radio_CheckedChanged);
            this.pointer_radio.Click += new System.EventHandler(this.pointer_radio_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(125, 352);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // Help_Btn
            // 
            this.Help_Btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Help_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Help_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help_Btn.ForeColor = System.Drawing.Color.IndianRed;
            this.Help_Btn.Location = new System.Drawing.Point(0, 747);
            this.Help_Btn.Name = "Help_Btn";
            this.Help_Btn.Size = new System.Drawing.Size(190, 54);
            this.Help_Btn.TabIndex = 19;
            this.Help_Btn.Text = "Help\r\n";
            this.Help_Btn.UseVisualStyleBackColor = false;
            this.Help_Btn.Click += new System.EventHandler(this.Help_Btn_Click);
            // 
            // TextBtn
            // 
            this.TextBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.TextBtn.Location = new System.Drawing.Point(0, 342);
            this.TextBtn.Name = "TextBtn";
            this.TextBtn.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.TextBtn.Size = new System.Drawing.Size(190, 59);
            this.TextBtn.TabIndex = 3;
            this.TextBtn.Text = "Text";
            this.TextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextBtn.UseVisualStyleBackColor = false;
            this.TextBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBtn_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(125, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // LineBtnPic
            // 
            this.LineBtnPic.Image = ((System.Drawing.Image)(resources.GetObject("LineBtnPic.Image")));
            this.LineBtnPic.Location = new System.Drawing.Point(125, 297);
            this.LineBtnPic.Name = "LineBtnPic";
            this.LineBtnPic.Size = new System.Drawing.Size(50, 39);
            this.LineBtnPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LineBtnPic.TabIndex = 18;
            this.LineBtnPic.TabStop = false;
            // 
            // CircleBtnPic
            // 
            this.CircleBtnPic.Image = ((System.Drawing.Image)(resources.GetObject("CircleBtnPic.Image")));
            this.CircleBtnPic.Location = new System.Drawing.Point(125, 179);
            this.CircleBtnPic.Name = "CircleBtnPic";
            this.CircleBtnPic.Size = new System.Drawing.Size(50, 43);
            this.CircleBtnPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CircleBtnPic.TabIndex = 17;
            this.CircleBtnPic.TabStop = false;
            // 
            // connections
            // 
            this.connections.AutoSize = true;
            this.connections.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connections.ForeColor = System.Drawing.Color.IndianRed;
            this.connections.Location = new System.Drawing.Point(33, 581);
            this.connections.Name = "connections";
            this.connections.Size = new System.Drawing.Size(130, 17);
            this.connections.TabIndex = 2;
            this.connections.Text = "Connection Type";
            // 
            // connectionType
            // 
            this.connectionType.FormattingEnabled = true;
            this.connectionType.Items.AddRange(new object[] {
            "Default",
            "Circle - Circle",
            "Circle - Rectangle",
            "Rectangle - Rectangle",
            "Circle - Triangle",
            "Rectangle - Triangle",
            "Triangle - Triangle"});
            this.connectionType.Location = new System.Drawing.Point(12, 601);
            this.connectionType.Name = "connectionType";
            this.connectionType.Size = new System.Drawing.Size(163, 24);
            this.connectionType.TabIndex = 2;
            this.connectionType.SelectedIndexChanged += new System.EventHandler(this.connectionType_SelectedIndexChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(125, 402);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 49);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // MainAPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 864);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.skControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainAPP";
            this.Text = "DiaNotes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineBtnPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircleBtnPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkiaSharp.Views.Desktop.SKControl skControl1;
        private System.Windows.Forms.RadioButton Pointer_Btn;
        private System.Windows.Forms.RadioButton connector_Tool;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ShapesBtn;
        private System.Windows.Forms.Button TriBtn;
        private System.Windows.Forms.Button CircleBtn;
        private System.Windows.Forms.Button RectangleBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button ToolsBtn;
        private System.Windows.Forms.Button aboutBoxBtn;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox LineBtnPic;
        private System.Windows.Forms.PictureBox CircleBtnPic;
        private System.Windows.Forms.Button Help_Btn;
        private System.Windows.Forms.Label connections;
        private System.Windows.Forms.ComboBox connectionType;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button TextBtn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton pointer_radio;
        private System.Windows.Forms.RadioButton connector_radio;
        private System.Windows.Forms.Button import_btn;
        private System.Windows.Forms.Button diamondBtn;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

