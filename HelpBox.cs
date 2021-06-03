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
    public partial class HelpBox : Form
    {
        public HelpBox()
        {
            InitializeComponent();
        }

        private void HelpBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To activate drag you must click the tools button and select pointer, then click and hold each shape for drag feature.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To create a shape you must click the shapes button, then click and drag a shape to the interface to create a shape. " +
                "If pointer in tools is active then turn off to make more shapes.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To create a connection you must click the tools button and select connectors to make connections between shapes. " +
                "Make sure to deselect pointer to create connection.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the mouse to grab the shape while pointer from tools is active and scroll the wheel up or down to zoom in and out, respectively. ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Right click each shape for deletion.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the text box from the shapes button, double click the textbox and use mouse and keyboard to add and update text.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Double click the shape, then Choose the color you want within the variation provided. ");
        }
    }
}
