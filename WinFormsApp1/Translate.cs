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
    public partial class Translate : Form
    {
        public double XOffset { get; set; }
        public double YOffset { get; set; }

        public Translate()
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

        private void txtXAxis_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (txtXAxis.Text != "")
            {
                try
                {
                    XOffset = double.Parse(txtXAxis.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid input. Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtXAxis.Text = "";
                }
            }
        }

        private void txtYAxis_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (txtYAxis.Text != "")
            {
                try
                {
                    YOffset = double.Parse(txtYAxis.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid input. Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYAxis.Text = "";
                }
            }
        }
    }
}
