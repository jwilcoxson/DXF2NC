using netDxf.Entities;
using netDxf;
using Svg;
using Svg.Pathing;

namespace DXF2NC
{
    public partial class MainForm : Form
    {
        private DxfDocument doc = new();
        private Polyline2D pline = new();
        private List<Polyline2DVertex> vertices = [];
        private bool loaded = false;
        private string format = "0.000";
        private List<DXF2NC.GCodeCommand> commands = [];
        private int line_counter = 0;

        public MainForm()
        {
            InitializeComponent();
            foreach (ToolStripItem t in toolStrip1.Items)
            {
                t.Enabled = false;
            }
            foreach (ToolStripDropDownItem t in editToolStripMenuItem.DropDownItems)
            {
                t.Enabled = false;
            }
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
                this.commands = pathGenerator.GeneratePath(vertices, (int)numFeedRate.Value);
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
            if (loaded)
            {
                cmbLayer.SelectedIndex = 0;
                cmbLayer.Enabled = true;
                cmbPolyline.Enabled = true;
                foreach (ToolStripItem t in toolStrip1.Items)
                {
                    t.Enabled = true;
                }
                foreach (ToolStripDropDownItem t in editToolStripMenuItem.DropDownItems)
                {
                    t.Enabled = true;
                }
            }
            GCodeUpdate();
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

        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
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


        private void rotLeftToolStripButton_Click(object sender, EventArgs e)
        {
            var angle = -90;
            var matrix4 = Matrix4.RotationZ(angle * Math.PI / 180);
            pline.TransformBy(matrix4);
            GCodeUpdate();
        }

        private void rotRightToolStripButton_Click(object sender, EventArgs e)
        {
            var angle = 90;
            var matrix4 = Matrix4.RotationZ(angle * Math.PI / 180);
            pline.TransformBy(matrix4);
            GCodeUpdate();
        }

        private void invertXToolStripButton_Click(object sender, EventArgs e)
        {
            var matrix4 = Matrix4.Scale(-1, 1, 1);
            pline.TransformBy(matrix4);
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
        }

        private void invertYToolStripButton_Click(object sender, EventArgs e)
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

        private void reversePathToolStripButton_Click(object sender, EventArgs e)
        {
            pline.Reverse();
            vertices = [.. pline.Vertexes.Where(p => true)];
            GCodeUpdate();
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
            toolStripMenuItem7.Checked = true;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = false;
            GCodeUpdate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            format = "0.0000";
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = true;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = false;
            GCodeUpdate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            format = "0.00000";
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = true;
            toolStripMenuItem10.Checked = false;
            GCodeUpdate();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            format = "0.000000";
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = true;
            GCodeUpdate();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doc = new();
            pline = new();
            vertices = [];
            loaded = false;
            this.Text = "DXF2NC";
            txtOutput.Text = "";
            dgvPoints.Rows.Clear();
            dgvTraversing.Rows.Clear();
            cmbLayer.Items.Clear();
            cmbLayer.Enabled = false;
            cmbPolyline.Items.Clear();
            cmbPolyline.Enabled = false;
            foreach (ToolStripItem t in toolStrip1.Items)
            {
                t.Enabled = false;
            }
        }

        private void tabView_Paint(object sender, PaintEventArgs e)
        {
            SvgDocument svg = new();
            var circ = false;
            var b = 0.0;

            // Get min and max X values
            var minX = vertices.Min(p => p.Position.X);
            var maxX = vertices.Max(p => p.Position.X);
            var minY = vertices.Min(p => p.Position.Y);
            var maxY = vertices.Max(p => p.Position.Y);

            if (loaded)
            {
                var last_x = 0.0;
                var last_y = 0.0;
                var color = new SvgColourServer(Color.Black);

                foreach (var v in vertices)
                {
                    if (ReferenceEquals(v, vertices.First()))
                    {
                        svg.Children.Add(new SvgCircle()
                        {
                            CenterX = (float)v.Position.X,
                            CenterY = (float)v.Position.Y,
                            Radius = 1,
                            Fill = new SvgColourServer(Color.Red)
                        });
                    }
                    else if (ReferenceEquals(v, vertices.Last()))
                    {
                        svg.Children.Add(new SvgCircle()
                        {
                            CenterX = (float)v.Position.X,
                            CenterY = (float)v.Position.Y,
                            Radius = 1,
                            Fill = new SvgColourServer(Color.Green)
                        });
                        svg.Children.Add(new SvgLine()
                        {
                            StartX = (float)last_x,
                            StartY = (float)last_y,
                            EndX = (float)v.Position.X,
                            EndY = (float)v.Position.Y,
                            Stroke = new SvgColourServer(Color.Black),
                            StrokeWidth = 1
                        });
                    }
                    else
                    {
                        svg.Children.Add(new SvgCircle()
                        {
                            CenterX = (float)v.Position.X,
                            CenterY = (float)v.Position.Y,
                            Radius = 1,
                            Fill = new SvgColourServer(Color.Blue)
                        });

                        if (!circ)
                        {
                            svg.Children.Add(new SvgLine()
                            {
                                StartX = (float)last_x,
                                StartY = (float)last_y,
                                EndX = (float)v.Position.X,
                                EndY = (float)v.Position.Y,
                                Stroke = color,
                                StrokeWidth = 1
                            });
                        }
                        else
                        {
                            var radius = (float)PathGenerator.CalcRadius(v.Position.X - last_x, v.Position.Y - last_y, b)/2;
                            var angle = (float)Math.Atan2(v.Position.Y - last_y, v.Position.X - last_x);
                            var start = new PointF((float)last_x, (float)last_y);
                            var end = new PointF((float)v.Position.X, (float)v.Position.Y);

                            var text = new SvgText()
                            {
                                X = new SvgUnitCollection() { (float)v.Position.X },
                                Y = new SvgUnitCollection() { (float)v.Position.Y },
                                Fill = color,
                                FontSize = 3,
                                Text = radius.ToString(format)
                            };
                            svg.Children.Add(text);
                        }



                        if (v.Bulge != 0.0)
                        {
                            color = new SvgColourServer(Color.Red);
                            circ = true;
                        }
                        else
                        {
                            color = new SvgColourServer(Color.Black);
                            circ = false;
                        }
                        b = v.Bulge;

                    }
                    last_x = v.Position.X;
                    last_y = v.Position.Y;
                }
            }

            // Center and scale SVG to fit in picture box
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var width = maxX - minX;
            var height = maxY - minY;
            svg.Width = (SvgUnit)(width);
            svg.Height = (SvgUnit)(height);
            svg.ViewBox = new SvgViewBox((float)minX, (float)minY, (float)width, (float)height);

            pictureBox1.Image = svg.Draw(pictureBox1.Width,0);
        }

    }
}
