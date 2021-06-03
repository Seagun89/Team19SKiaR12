using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Team19SKiaR12
{
    public partial class Export : Form
    {
        protected FolderBrowserDialog folderBrowserDialog;
        protected string path;
        public Export()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }
        
   
        public string GetFilePath()
        {
              
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
                string filename = "Canvas.png";
                path = Path.Combine(textBox1.Text, filename);
            }
            return path;
        }


        private void Export_Load(object sender, EventArgs e)
        {

        }


        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
