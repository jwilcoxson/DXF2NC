using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (Command == "G00" || Command == "G01")
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

}
