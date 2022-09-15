using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassForm.Objects
{
    public class Bishop : GameTool
    {
        public Bishop()
            : base()
        {

        }
        public Bishop(string name, Colors color, Image image)
            : base(color, name, image)
        {

        }
        public override List<Point> Move(string name, int xTool, int yTool, int Cube, bool atStart, int offset)
        {
            List<Point> points = new List<Point>();
            if (name == this.name)
            {
                if (this.color == Colors.black)
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        points.Add(new Point(xTool - Cube * i, yTool + Cube * i));
                        points.Add(new Point(xTool + Cube * i, yTool + Cube * i));
                    }
                   if(!atStart)
                    {
                        for (int i = 1; i <= 8; i++)
                        {
                            points.Add(new Point(xTool - Cube * i, yTool - Cube * i));
                            points.Add(new Point(xTool + Cube * i, yTool - Cube * i));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        points.Add(new Point(xTool - Cube * i, yTool - Cube * i));
                        points.Add(new Point(xTool + Cube * i, yTool - Cube * i));
                        
                    }
                    if (!atStart)
                    {
                        for (int i = 1; i <= 8; i++)
                        {
                            points.Add(new Point(xTool - Cube * i, yTool + Cube * i));
                            points.Add(new Point(xTool + Cube * i, yTool + Cube * i));
                        }
                    }
                }
            }
            return points;
        }
    }
}
