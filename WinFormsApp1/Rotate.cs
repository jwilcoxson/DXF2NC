using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXF2NC
{
    public partial class Rotate : Form
    {
        public double Angle { get; set; }

        public Rotate()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (txtAngle.Text != "")
            {
                try
                {
                    Angle = double.Parse(txtAngle.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid input. Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAngle.Text = "";
                }
            }
        }

    }
}
