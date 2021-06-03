using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team19SKiaR12
{
    public partial class PropertiesBox : Form
    {
        protected bool check = true;
        protected bool previousCheck = true;
        public PropertiesBox()
        {
            InitializeComponent();
        }

    
        public string GetDeviceName()
        {
            return descripTextBox.Text.ToString();
            
        }
        public string GetColorChoice()
        {
            return comboBox1.Text.ToString();
        }


        private void PropertiesBox_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            
        }

        public string getStrokeAndFillChoice()
        {
            return strokeBox.Text.ToString();
        }

       

        public bool getShowBox()
        {
            return showShape.Checked;
        }


        /// <summary>
        /// Issue with properties box throwing an exception when user tried to reopen the properties box of a shape:
        /// https://stackoverflow.com/questions/6993407/cannot-access-a-disposed-object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void PropertiesBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
            
        }
    }
}
