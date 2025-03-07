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

        // Calculate radius of circular move using dx, dy and DXF LWPOLYLINE 'bulge' field
        public static double CalcRadius(double dx, double dy, double b)
        {
            var h = Math.Sqrt(dx * dx + dy * dy);
            var d = h / 2;
            var r = (d * ((b * b) + 1)) / (2 * b);
            return Math.Abs(r);
        }

        public static double CalculateArcLength(double dx, double dy, double radius)
        {
            var chordLength = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            var theta = 2 * Math.Asin(chordLength / (2 * radius));
            var arcLength = radius * theta;
            return arcLength;
        }


        public List<GCodeCommand> GeneratePath(List<Polyline2DVertex> vertices, int feed_rate = 5000)
        {
            List<GCodeCommand> cmds = [];

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
                    cmds.Add(new GCodeCommand("G90"));
                    cmds.Add(new GCodeCommand("F" + feed_rate.ToString("0")));
                    cmds.Add(new GCodeCommand("G00", x, y, 0.0, feed_rate));
                    cmds.Add(new GCodeCommand("G91"));
                }
                else
                {
                    // G02: Clockwise move
                    if (cw_move)
                    {
                        cmds.Add(new GCodeCommand("G02", dx, dy, r, feed_rate));
                    }
                    // G03: Counterclockwise move
                    else if (ccw_move)
                    {
                        cmds.Add(new GCodeCommand("G03", dx, dy, r, feed_rate));
                    }
                    // G01: Linear Move
                    else
                    {
                        cmds.Add(new GCodeCommand("G01", dx, dy, 0.0, feed_rate));
                    }
                }

                prev_x = x;
                prev_y = y;
            }
            return cmds;
        }
    }
}
