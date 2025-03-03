using netDxf.Entities;
using netDxf;
using System.Drawing.Drawing2D;
using DXF2NC;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DxfDocument doc = new();
        Polyline2D pline = new();
        List<Polyline2DVertex> vertices = [];
        bool loaded = false;

        string format = "0.000";

        public Form1()
        {
            InitializeComponent();

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
                    cmbLayer.SelectedIndex = 0;

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
        

        private void GCodeUpdate()
        {
            if (loaded)
            {
                var header = "(Generated from " + doc.Name + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")" + Environment.NewLine;
                header += "(Layer: " + pline.Layer.Name + ")" + Environment.NewLine;
                header += "(Handle: " + pline.Handle + ")" + Environment.NewLine;
                header += "(Vertices: " + vertices.Count + ")" + Environment.NewLine;
                header += "(Invert X: " + chkInvertX.Checked + ")" + Environment.NewLine;
                header += "(Invert Y: " + chkInvertY.Checked + ")" + Environment.NewLine;
                header += "(Reverse Path: " + chkReversePath.Checked + ")";

                PathGenerator pathGenerator = new();
                txtOutput.Text = pathGenerator.GeneratePath(vertices, chkStartAbs.Checked, (int)numFeedRate.Value, format, header);
                txtOutput.Text += Environment.NewLine + "(Length: " + pathGenerator.length.ToString(format) + ")";
                txtOutput.Text += Environment.NewLine + "(Time: " + pathGenerator.time.ToString(format) + "s)";

                dgvPoints.Rows.Clear();
                for (int i = 1; i <= vertices.Count; i++)
                {
                    var v = vertices[i - 1];
                    dgvPoints.Rows.Add(i, v.Position.X.ToString(format), v.Position.Y.ToString(format), v.Bulge.ToString(format));
                }
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
                            var r = (float)PathGenerator.CalcRadius(next_x - x, next_y - y, vertices[i].Bulge);
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
            cmbPolyline.Items.Clear();
            foreach (var pline in doc.Entities.Polylines2D.Where(p => p.Layer.Name == cmbLayer.SelectedItem.ToString()))
            {
                cmbPolyline.Items.Add(pline.Handle);
            }
            if (cmbPolyline.Items.Count > 0)
            {
                cmbPolyline.SelectedIndex = 0;
            }
        }

        private void numPrecision_ValueChanged(object sender, EventArgs e)
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

        private void translateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var translate = new DXF2NC.Translate();
            translate.ShowDialog();
            if (translate.DialogResult == DialogResult.OK)
            {
                var x_offset = translate.XOffset;
                var y_offset = translate.YOffset;
                var matrix4 = Matrix4.Translation(x_offset, y_offset, 0);
                pline.TransformBy(matrix4);
                vertices = [.. pline.Vertexes.Where(p => true)];
                GCodeUpdate();
            }
        }

        private void cmbPolyline_SelectedIndexChanged(object sender, EventArgs e)
        {
            pline = doc.Entities.Polylines2D.First(p => p.Handle == cmbPolyline.SelectedItem.ToString());
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rotate = new DXF2NC.Rotate();
            rotate.ShowDialog();
            if (rotate.DialogResult == DialogResult.OK)
            {
                var angle = rotate.Angle;
                var matrix4 = Matrix4.RotationZ(angle);
                pline.TransformBy(matrix4);
                vertices = [.. pline.Vertexes.Where(p => true)];
                GCodeUpdate();
            }
        }
    }
}
