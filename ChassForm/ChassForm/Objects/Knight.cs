using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassForm.Objects
{
    public class Knight : GameTool
    {
        public Knight()
            : base()
        {

        }
        public Knight(string name, Colors color, Image image)
            : base(color, name, image)
        {

        }
        public override List<Point> Move(string name, int xTool, int yTool, int Cube, bool atStart, int offset)
        {
            List<Point> points = new List<Point>();
            if (name == this.name)
            {

                points.Add(new Point(xTool - Cube * 2, yTool + Cube));
                points.Add(new Point(xTool + Cube, yTool + Cube * 2));
                points.Add(new Point(xTool - Cube, yTool + Cube * 2));
                points.Add(new Point(xTool + Cube * 2, yTool + Cube));
                points.Add(new Point(xTool + Cube * 2, yTool - Cube));
                points.Add(new Point(xTool - Cube * 2, yTool - Cube));
                points.Add(new Point(xTool + Cube, yTool - Cube * 2));
                points.Add(new Point(xTool - Cube, yTool - Cube * 2));

            }
            return points;

        }
    }
}
