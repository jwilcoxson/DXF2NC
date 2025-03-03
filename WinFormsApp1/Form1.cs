using netDxf.Entities;
using netDxf;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DxfDocument doc = new();
        Polyline2D pline = new();
        List<Polyline2DVertex> vertices = [];
        bool loaded = false;
        int count = 0;
        string format = "0.000";

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
                    this.Text = "DXF2NC - " + doc.Name;
                    foreach (var layer in doc.Layers)
                    {
                        cmbLayer.Items.Add(layer.Name);
                    }
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
            var start_abs = chkStartAbs.Checked;
            dgvPoints.Rows.Clear();

            // Generate G-code header
            List<string> lines =
            [
                "(Generated from " + doc.Name + ")",
                "(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")",
                "(Invert X: " + (chkInvertX.Checked ? "Yes" : "No") + ")",
                "(Invert Y: " + (chkInvertY.Checked ? "Yes" : "No") + ")",
                "(Reverse Path: " + (chkReversePath.Checked ? "Yes" : "No") + ")",
                "N" + LineCounter() + " F" + numFeedRate.Value,
            ];

            var b = 0.0;
            var circ = false;
            var prev_x = 0.0;
            var prev_y = 0.0;

            // Iterate over remaining vertices, generate path
            foreach (var v in vertices)
            {
                dgvPoints.Rows.Add(dgvPoints.Rows.Count + 1, v.Position.X.ToString(format), v.Position.Y.ToString(format), v.Bulge.ToString(format));
                var cw_move = false;
                var ccw_move = false;
                var r = 0.0;
                var x = v.Position.X;
                var y = v.Position.Y;
                var dx = x - prev_x;
                var dy = y - prev_y;

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
                        lines.Add("(Absolute positioning)");
                        lines.Add("N" + LineCounter() + " G90");
                        lines.Add("(Rapid move to start point)");
                        lines.Add("N" + LineCounter() + " G00 X" + dx.ToString(format) + " Y" + dy.ToString(format));
                    }
                    lines.Add("(Relative positioning)");
                    lines.Add("N" + LineCounter() + " G91");
                    lines.Add("(Path)");
                }
                else
                {
                    // G02: Clockwise move
                    if (cw_move)
                    {
                        lines.Add("N" + LineCounter() + " G02 X" + dx.ToString(format) + " Y" + dy.ToString(format) + " U" + r.ToString(format));
                    }
                    // G03: Counterclockwise move
                    else if (ccw_move)
                    {
                        lines.Add("N" + LineCounter() + " G03 X" + dx.ToString(format) + " Y" + dy.ToString(format) + " U" + r.ToString(format));
                    }
                    // G01: Linear Move
                    else
                    {
                        lines.Add("N" + LineCounter() + " G01 X" + dx.ToString(format) + " Y" + dy.ToString(format));
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
            var matrix4 = Matrix4.Scale(-1, 1, 1);
            pline.TransformBy(matrix4);
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void chkInvertY_CheckedChanged(object sender, EventArgs e)
        {
            var matrix4 = Matrix4.Scale(1, -1, 1);
            pline.TransformBy(matrix4);
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void chkReversePath_CheckedChanged(object sender, EventArgs e)
        {
            pline.Reverse();
            vertices = [.. pline.Vertexes.Where(p => true)];
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
                var span_x = max_x - min_x;
                var span_y = max_y - min_y;
                var x_scale = (width) / span_x;
                var y_scale = (height) / span_y;

                var scale = Math.Min(x_scale, y_scale) * 0.9;

                var x_offset = -min_x * scale + (width - span_x * scale) / 2;
                var y_offset = -min_y * scale + (height - span_y * scale) / 2;

                for (int i = 0; i < vertices.Count; i++)
                {
                    var x = (float)(vertices[i].Position.X * scale + x_offset);
                    var y = (float)(vertices[i].Position.Y * scale + y_offset);

                    if (i > 0 && i < (vertices.Count - 1))
                    {
                        var next_x = (float)(vertices[i + 1].Position.X * scale + x_offset);
                        var next_y = (float)(vertices[i + 1].Position.Y * scale + y_offset);
                        var dx = next_x - x;
                        var dy = next_y - y;

                        if (vertices[i].Bulge != 0.0)
                        {
                            var r = (float)CalcRadius(next_x - x, next_y - y, vertices[i].Bulge);
                            g.DrawString("R: " + (r / scale).ToString(format), new Font("Arial", 8), Brushes.Black, x + dx / 2, y + dy / 2);

                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Black, 2), x, y, next_x, next_y);
                        }
                    }
                    else if (i == 0)
                    {
                        g.DrawEllipse(new Pen(Color.Red, 2), x - 5, y - 5, 10, 10);
                        g.DrawString("Start", new Font("Arial", 8), Brushes.Black, x + 5, y + 5);
                        g.DrawString("X: " + vertices[i].Position.X.ToString(format), new Font("Arial", 8), Brushes.Black, x + 5, y + 15);
                        g.DrawString("Y: " + vertices[i].Position.Y.ToString(format), new Font("Arial", 8), Brushes.Black, x + 5, y + 25);
                    }
                    if (i == vertices.Count - 1)
                    {
                        g.DrawEllipse(new Pen(Color.Green, 2), x - 5, y - 5, 10, 10);
                        g.DrawString("End", new Font("Arial", 8), Brushes.Black, x + 5, y + 5);
                        g.DrawString("X: " + vertices[i].Position.X.ToString(format), new Font("Arial", 8), Brushes.Black, x + 5, y + 15);
                        g.DrawString("Y: " + vertices[i].Position.Y.ToString(format), new Font("Arial", 8), Brushes.Black, x + 5, y + 25);
                    }
                }
            }
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            pline = doc.Entities.Polylines2D.First(p => p.Layer.Name == cmbLayer.SelectedItem.ToString());
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            format = "0." + new string('0', (int)numericUpDown1.Value);
            GCodeUpdate();
        }


        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var scale = new DXF2NC.Scale();
            scale.ShowDialog();
            if (scale.DialogResult == DialogResult.OK)
            {
                var x_scale = scale.XScale;
                var y_scale = scale.YScale;
                var matrix4 = Matrix4.Scale(x_scale, y_scale, 1);
                pline.TransformBy(matrix4);
                vertices = [.. pline.Vertexes.Where(p => true)];
                GCodeUpdate();
            }
        }
    }
}
