using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Entities;
using static System.Windows.Forms.DataFormats;

namespace DXF2NC
{
    class PathGenerator
    {
        int count = 0;
        public double length = 0.0;
        public double time = 0.0;

        // Generate incremental line numbers
        private string LineCounter()
        {
            count = count + 10;
            return count.ToString("D4");
        }


        // Calculate radius of circular move using dx, dy and DXF LWPOLYLINE 'bulge' field
        public static double CalcRadius(double dx, double dy, double b)
        {
            var h = Math.Sqrt(dx * dx + dy * dy);
            var d = h / 2;
            var r = (d * ((b * b) + 1)) / (2 * b);
            return Math.Abs(r);
        }

        public static double CalculateArcLength(double x1, double y1, double x2, double y2, double bulge)
        {
            var chordLength = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            var theta = 4 * Math.Atan(Math.Abs(bulge));
            var radius = chordLength / (2 * Math.Sin(theta / 2));
            var arcLength = radius * theta;
            return arcLength;
        }


        public string GeneratePath(List<Polyline2DVertex> vertices, bool start_abs=false, int feed_rate=5000, string format="0.000", string header="", string footer="")
        {

            // Generate G-code header
            List<string> lines =
            [
                header,
                "N" + LineCounter() + " F" + feed_rate,
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
                        length += CalculateArcLength(prev_x, prev_y, x, y, b);
                        lines.Add("N" + LineCounter() + " G02 X" + dx.ToString(format) + " Y" + dy.ToString(format) + " U" + r.ToString(format));
                    }
                    // G03: Counterclockwise move
                    else if (ccw_move)
                    {
                        length += CalculateArcLength(prev_x, prev_y, x, y, b);
                        lines.Add("N" + LineCounter() + " G03 X" + dx.ToString(format) + " Y" + dy.ToString(format) + " U" + r.ToString(format));
                    }
                    // G01: Linear Move
                    else
                    {
                        length += Math.Sqrt(dx * dx + dy * dy);
                        lines.Add("N" + LineCounter() + " G01 X" + dx.ToString(format) + " Y" + dy.ToString(format));
                    }
                }

                prev_x = x;
                prev_y = y;

            }

            lines.Add("N" + LineCounter() + " M30");
            lines.Add(footer);
            string output = "";
            count = 0;

            foreach (string s in lines)
            {
                output = output + s + Environment.NewLine;
            }
            time = length / feed_rate * 60;
            return output;
        }
    }
}
