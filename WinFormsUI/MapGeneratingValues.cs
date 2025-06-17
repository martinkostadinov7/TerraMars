using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsUI
{
    public partial class MapGeneratingValues : Form
    {
        public int Rows => int.Parse(textBox1.Text);
        public int Cols => int.Parse(textBox2.Text);
        public string Name => textBox3.Text;

        public MapGeneratingValues()
        {
            InitializeComponent();
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                throw new Exception("Rows and Cols fields are required to generate a map!");
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "40";
            textBox2.Text = "70";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "30";
            textBox2.Text = "30";
        }
    }
}
