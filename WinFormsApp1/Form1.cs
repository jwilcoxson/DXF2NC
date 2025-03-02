using netDxf.Entities;
using netDxf;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DxfDocument doc = new();
        bool loaded = false;
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Calculate radius of circular move using dx, dy and DXF LWPOLYLINE 'bulge' field
        public static double CalcRadius(double dx, double dy, double b)
        {
            var h = Math.Sqrt(dx * dx + dy * dy);
            var d = h / 2;
            var r = (d * ((b * b) + 1)) / (2 * b);
            return Math.Abs(r);
        }

        // Generate incremental line numbers
        public string LineCounter()
        {
            count = count + 10;
            return count.ToString("D4");
        }

        // Open DXF file
        public bool OpenFromFile()
        {
            OpenFileDialog dialog = new()
            {
                Filter = "DXF Files (*.DXF)|*.DXF|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var file_name = dialog.FileName;
                try
                {
                    doc = DxfDocument.Load(file_name);
                    txtFileName.Text = dialog.SafeFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading file");
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GeneratePath(DxfDocument doc)
        {
            // Get vertices of the first Polyline on the "Path" layer
            var pline = doc.Entities.Polylines2D.Where(p => p.Layer.Name == "Path").First();
            var vertices = pline.Vertexes.Where(p => true).ToList();
            var reverse_path = chkReversePath.Checked;
            var invert_x = chkInvertX.Checked;
            var invert_y = chkInvertY.Checked;

            if (reverse_path)
            {
                vertices.Reverse();
            }

            // Generate G-code header
            List<string> lines =
            [
                "(Generated from " + txtFileName.Text + ")",
                "(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")",
                "(Invert X: " + (invert_x ? "Yes" : "No") + ")",
                "(Invert Y: " + (invert_y ? "Yes" : "No") + ")",
                "(Reverse Path: " + (reverse_path ? "Yes" : "No") + ")",
                // Set feed rate
                "N" + LineCounter() + " F" + numFeedRate.Value,
                // Set relative move mode
                "N" + LineCounter() + " G91",
            ];

            var b = 0.0;
            var circ = false;
            var prev_x = 0.0;
            var prev_y = 0.0;

            // Iterate over remaining vertices, generate path
            foreach (var v in vertices)
            {
                var cw_move = false;
                var ccw_move = false;
                var r = 0.0;
                var x = v.Position.X;
                var y = v.Position.Y;
                var dx = x - prev_x;
                var dy = y - prev_y;

                dx = invert_x ? -dx : dx;
                dx = (dx == double.NegativeZero) ? 0.0 : dx;
                dy = invert_y ? -dy : dy;
                dy = (dy == double.NegativeZero) ? 0.0 : dy;

                // If completing circular move, calculate radius
                if (circ)
                {
                    r = CalcRadius(dx, dy, b);
                    cw_move = b < 0.0;
                    ccw_move = b > 0.0;
                    circ = false;
                }

                // Determine if starting circular move
                if (v.Bulge != 0.0)
                {
                    b = v.Bulge;
                    circ = true;
                }

                if (ReferenceEquals(v, vertices.First()))
                {
                    if (chkStartAbs.Checked)
                    {
                        lines.Add("N" + LineCounter() + " G00 X" + dx.ToString("0.000") + " Y" + dy.ToString("0.000"));
                    }
                }
                else
                {
                    // G02: Clockwise move
                    if (cw_move)
                    {
                        lines.Add("N" + LineCounter() + " G02 X" + dx.ToString("0.000") + " Y" + dy.ToString("0.000") + " U" + r.ToString("0.000"));
                    }
                    // G03: Counterclockwise move
                    else if (ccw_move)
                    {
                        lines.Add("N" + LineCounter() + " G03 X" + dx.ToString("0.000") + " Y" + dy.ToString("0.000") + " U" + r.ToString("0.000"));
                    }
                    // G01: Linear Move
                    else
                    {
                        lines.Add("N" + LineCounter() + " G01 X" + dx.ToString("0.000") + " Y" + dy.ToString("0.000"));
                    }
                }

                prev_x = x;
                prev_y = y;

            }
            lines.Add("N" + LineCounter() + " M30");
            string output = "";
            count = 0;
            foreach (string s in lines)
            {
                output = output + s + Environment.NewLine;
            }
            txtOutput.Text = output;
        }

        private void GCodeUpdate()
        {
            if (loaded)
            {
                GeneratePath(doc);
            }
        }

        private void chkInvertX_CheckedChanged(object sender, EventArgs e)
        {
            GCodeUpdate();
        }

        private void chkInvertY_CheckedChanged(object sender, EventArgs e)
        {
            GCodeUpdate();
        }

        private void chkReversePath_CheckedChanged(object sender, EventArgs e)
        {
            GCodeUpdate();
        }

        private void numFeedRate_ValueChanged(object sender, EventArgs e)
        {
            GCodeUpdate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loaded = OpenFromFile();
            GCodeUpdate();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
        }

        private void chkStartAbs_CheckedChanged(object sender, EventArgs e)
        {
            GCodeUpdate();
        }
    }
}
