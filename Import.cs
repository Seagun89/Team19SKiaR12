using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team19SKiaR12
{
    public partial class Import : Form
    {
        protected OpenFileDialog fileDialog;
        protected string path;
        public Import()
        {
            InitializeComponent();
            fileDialog = new OpenFileDialog();
        }

        public string GetFilePath()
        {
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialog.FileName;
                path = textBox1.Text.ToString();
            }

            return path;
        }

        private void Import_Load(object sender, EventArgs e)
        {

        }
    }
}
