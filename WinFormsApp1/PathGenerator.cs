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

    class GCodeCommand
    {
        public string Command = "";
        public double X = 0.0;
        public double Y = 0.0;
        public double FeedRate = 0.0;
        public double Bulge = 0.0;
        public double Radius = 0.0;
        public double Length = 0.0;
        public double Time = 0.0;
        public double XVelocity = 0.0;
        public double YVelocity = 0.0;

        public GCodeCommand(string command, double x = 0.0, double y = 0.0, double radius = 0.0, double feed_rate = 1000.0)
        {
            Command = command;
            X = x;
            Y = y;
            Radius = radius;
            FeedRate = feed_rate;
            switch (command)
            {
                case "G01":
                    Length = Math.Sqrt(x * x + y * y);
                    Time = Length / feed_rate * 60;
                    XVelocity = x / Time;
                    YVelocity = y / Time;
                    break;
                case "G02":
                case "G03":
                    Length = PathGenerator.CalculateArcLength(x, y, radius);
                    Time = Length / feed_rate * 60;
                    break;
            }
        }

        public string ToString(string format)
        {
            if (Command == "G01" || Command == "G01")
            {
                return Command + " X" + X.ToString(format) + " Y" + Y.ToString(format);
            }
            else if (Command == "G02" || Command == "G03")
            { 
                return Command + " X" + X.ToString(format) + " Y" + Y.ToString(format) + " U" + Radius.ToString(format); 
            }
            else
            {
                return Command;
            }

        }
    }

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


        public List<GCodeCommand> GeneratePath(List<Polyline2DVertex> vertices, bool start_abs = false, int feed_rate = 5000)
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
