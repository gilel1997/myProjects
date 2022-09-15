using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassForm.Objects
{
    public class King : GameTool
    {
        public King()
            : base()
        {

        }
        public King(string name, Colors color, Image image)
            : base(color, name, image)
        {

        }
        public override List<Point> Move(string name, int xTool, int yTool, int Cube, bool atStart, int offset)
        {
            List<Point> points = new List<Point>();
            if (name == this.name)
            {
                points.Add(new Point(xTool, yTool + Cube));
                points.Add(new Point(xTool - Cube, yTool + Cube));
                points.Add(new Point(xTool + Cube, yTool + Cube));
                points.Add(new Point(xTool + Cube, yTool));
                points.Add(new Point(xTool - Cube, yTool));
                points.Add(new Point(xTool + Cube, yTool - Cube));
                points.Add(new Point(xTool - Cube, yTool - Cube));
                points.Add(new Point(xTool, yTool - Cube));
            }
            return points;
        }
    }
}
