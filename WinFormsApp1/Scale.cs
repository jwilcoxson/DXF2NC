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
    public partial class Scale : Form
    {
        public double XScale { get; set; }
        public double YScale { get; set; }


        public Scale()
        {
            XScale = 1.0;
            YScale = 1.0;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtXScale_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (txtXScale.Text != "")
            {
                try
                {
                    XScale = double.Parse(txtXScale.Text) / 100.0;
                }
                catch
                {
                    MessageBox.Show("Invalid input. Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtXScale.Text = "";
                }
            }
        }

        private void txtYScale_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (txtYScale.Text != "")
            {
                try
                {
                    YScale = double.Parse(txtYScale.Text) / 100.0;
                }
                catch
                {
                    MessageBox.Show("Invalid input. Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYScale.Text = "";
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
