using netDxf.Entities;
using netDxf;
using DXF2NC;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private DxfDocument doc = new();
        private Polyline2D pline = new();
        private List<Polyline2DVertex> vertices = [];
        private bool loaded = false;
        private string format = "0.000";
        private List<DXF2NC.GCodeCommand> commands = [];
        private int line_counter = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private string LineCounter()
        {
            line_counter += 10;
            return "N" + line_counter.ToString("D4");
        }

        // Open DXF file
        private bool OpenFromFile()
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
                line_counter = 0;
                PathGenerator pathGenerator = new();
                this.commands = pathGenerator.GeneratePath(vertices, false, (int)numFeedRate.Value);
                txtOutput.Text = string.Join(Environment.NewLine, commands.Select(p => LineCounter() + " " + p.ToString(format)));
                txtOutput.Text += Environment.NewLine + "(Length: " + commands.Sum(p => p.Length).ToString(format) + ")";
                txtOutput.Text += Environment.NewLine + "(Time: " + commands.Sum(p => p.Time).ToString(format) + "s)";
                dgvPoints.Rows.Clear();
                var index = 1;
                foreach (var v in vertices)
                {
                    dgvPoints.Rows.Add(index, v.Position.X.ToString(format), v.Position.Y.ToString(format), v.Bulge.ToString(format));
                    index++;
                }
                dgvTraversing.Rows.Clear();
                index = 1;
                foreach (var c in commands)
                {
                    dgvTraversing.Rows.Add(index, c.Command, c.X.ToString(format), c.Y.ToString(format), c.XVelocity.ToString(format), c.YVelocity.ToString(format));
                    index++;
                }
                panel1.Refresh();
            }
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
            cmbLayer.Enabled = loaded;
            cmbPolyline.Enabled = loaded;
            rotateToolStripMenuItem.Enabled = loaded;
            scaleToolStripMenuItem.Enabled = loaded;
            translateToolStripMenuItem1.Enabled = loaded;
            rotLeftToolStripButton1.Enabled = loaded;
            rotRightToolStripButton1.Enabled = loaded;
            invertXToolStripButton.Enabled = loaded;
            invertYToolStripButton.Enabled = loaded;
            reversePathToolStripButton.Enabled = loaded;
            toolStripDropDownButton1.Enabled = loaded;
            GCodeUpdate();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    Clipboard.SetText(txtOutput.Text);
                    break;
                case 1:
                    var text = "";
                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            text += cell.Value.ToString() + "\t";
                        }
                        text += Environment.NewLine;
                    }
                    Clipboard.SetText(text);
                    break;
                case 2:
                    Bitmap b = new(panel1.Width, panel1.Height);
                    panel1.DrawToBitmap(b, new Rectangle(0, 0, panel1.Width, panel1.Height));
                    Clipboard.SetImage(b);
                    break;
                default:
                    break;
            }

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
                        g.DrawEllipse(new Pen(Color.Green, 2), x - 5, y - 5, 10, 10);
                        g.DrawString("Start", new Font("Arial", 8), Brushes.Black, x + 5, y + 5);
                        g.DrawString("X: " + vertices[i].Position.X.ToString(format), new Font("Arial", 8), Brushes.Black, x + 5, y + 15);
                        g.DrawString("Y: " + vertices[i].Position.Y.ToString(format), new Font("Arial", 8), Brushes.Black, x + 5, y + 25);
                    }
                    if (i == vertices.Count - 1)
                    {
                        g.DrawEllipse(new Pen(Color.Red, 2), x - 5, y - 5, 10, 10);
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


        private void rotLeftToolStripButton1_Click(object sender, EventArgs e)
        {
            var angle = -90;
            var matrix4 = Matrix4.RotationZ(angle * Math.PI / 180);
            pline.TransformBy(matrix4);
            GCodeUpdate();
        }

        private void rotRightToolStripButton1_Click(object sender, EventArgs e)
        {
            var angle = 90;
            var matrix4 = Matrix4.RotationZ(angle * Math.PI / 180);
            pline.TransformBy(matrix4);
            GCodeUpdate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var matrix4 = Matrix4.Scale(-1, 1, 1);
            pline.TransformBy(matrix4);
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var matrix4 = Matrix4.Scale(1, -1, 1);
            pline.TransformBy(matrix4);
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void rotateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var rotate = new DXF2NC.Rotate();
            rotate.ShowDialog();
            if (rotate.DialogResult == DialogResult.OK)
            {
                var angle = rotate.Angle;
                var matrix4 = Matrix4.RotationZ(angle * Math.PI / 180);
                pline.TransformBy(matrix4);
                vertices = [.. pline.Vertexes.Where(p => true)];
                GCodeUpdate();
            }
        }

        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotLeftToolStripButton1_Click(sender, e);
        }

        private void counterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotRightToolStripButton1_Click(sender, e);
        }

        private void reversePathToolStripButton_Click(object sender, EventArgs e)
        {
            pline.Reverse();
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void tabCode_Click(object sender, EventArgs e)
        {

        }

        private void dgvPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPoints_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var pos = vertices[e.RowIndex].Position;
            switch (e.ColumnIndex)
            {
                case 1:
                    pos.X = double.Parse(dgvPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    vertices[e.RowIndex].Position = pos;
                    break;
                case 2:
                    pos.Y = double.Parse(dgvPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    vertices[e.RowIndex].Position = pos;
                    break;
                case 3:
                    vertices[e.RowIndex].Bulge = double.Parse(dgvPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    break;
                default:
                    break;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            format = "0.000";
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            GCodeUpdate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            format = "0.0000";
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            GCodeUpdate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            format = "0.00000";
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            GCodeUpdate();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            format = "0.000000";
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            GCodeUpdate();
        }
    }
}
