using netDxf.Entities;
using netDxf;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DxfDocument doc = new();
        Polyline2D pline = new();
        List<Polyline2DVertex> vertices = new();
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

        public void GeneratePath()
        {
            // Get vertices of the first Polyline on the "Path" layer
            pline = doc.Entities.Polylines2D.Where(p => p.Layer.Name == "Path").First();
            vertices = [.. pline.Vertexes.Where(p => true)];
            var reverse_path = chkReversePath.Checked;
            var invert_x = chkInvertX.Checked;
            var invert_y = chkInvertY.Checked;
            var start_abs = chkStartAbs.Checked;
            dgvPoints.Rows.Clear();

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
                "N" + LineCounter() + " F" + numFeedRate.Value,
            ];

            var b = 0.0;
            var circ = false;
            var prev_x = 0.0;
            var prev_y = 0.0;

            // Iterate over remaining vertices, generate path
            foreach (var v in vertices)
            {
                dgvPoints.Rows.Add(dgvPoints.Rows.Count + 1, v.Position.X.ToString("0.000"), v.Position.Y.ToString("0.000"), v.Bulge.ToString("0.000"));
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
                    if (start_abs)
                    {
                        lines.Add("N" + LineCounter() + " G90");
                        lines.Add("N" + LineCounter() + " G00 X" + dx.ToString("0.000") + " Y" + dy.ToString("0.000"));
                    }

                    lines.Add("N" + LineCounter() + " G91");
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
            panel1.Refresh();
        }

        private void GCodeUpdate()
        {
            if (loaded)
            {
                GeneratePath();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {   
                Graphics g = e.Graphics;
                System.Drawing.Point[] points = new System.Drawing.Point[vertices.Count];

                var width = panel1.Width;
                var height = panel1.Height;

                var min_x = vertices.Min(p => p.Position.X);
                var max_x = vertices.Max(p => p.Position.X);
                var min_y = vertices.Min(p => p.Position.Y);
                var max_y = vertices.Max(p => p.Position.Y);

                var dx = max_x - min_x;
                var dy = max_y - min_y;

                var margin = 10;

                var x_scale = (width - 2 * margin) / dx;
                var y_scale = (height - 2 * margin) / dy;

                var x_offset = -min_x * x_scale;
                var y_offset = -min_y * y_scale;

                for (int i = 0; i < vertices.Count; i++)
                {
                    points[i] = new System.Drawing.Point((int)(vertices[i].Position.X * x_scale + x_offset + margin), (int)(vertices[i].Position.Y * y_scale + y_offset + margin));
                }

                g.DrawLines(new Pen(Color.Black, 3), points);
            }
        }
    }
}
