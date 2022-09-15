using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassForm.Objects
{
    public class Pawn : GameTool
    {
        public Pawn()
            : base()
        {

        }
        public Pawn(string name, Colors color, Image image)
            : base(color, name, image)
        {

        }
        public override List<Point> Move(string name, int xTool, int yTool, int cube, bool atStart, int offset)
        {
            List <Point> points = new List <Point>();
            if (name == this.name)
            {
                if (this.color == Colors.black)
                {
                    if (atStart)
                    {
                        points.Add(new Point(xTool, yTool + 2 * cube));
                        points.Add(new Point(xTool, yTool + cube));
                    }
                    else
                    {
                        points.Add(new Point(xTool, yTool + cube));
                    }
                }
                else
                {
                    if (atStart)
                    {
                        points.Add(new Point(xTool, yTool - 2 * cube));
                        points.Add(new Point(xTool, yTool - cube));
                    }
                    else
                    {
                        points.Add(new Point(xTool, yTool - cube));
                    }
                }
            }
            return points;
        }
    }
}
