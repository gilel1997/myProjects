using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassForm.Objects
{
    public class Rook : GameTool
    {
        public Rook()
            : base()
        {

        }
        public Rook(string name, Colors color, Image image)
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
                        if (yTool + Cube * i < Limit && xTool + Cube * i < Limit)
                        {
                            points.Add(new Point(xTool + Cube * i, yTool));
                            points.Add(new Point(xTool, yTool + Cube * i));
                        }
                        else if(xTool + Cube * i < Limit)
                        {
                            points.Add(new Point(xTool + Cube * i, yTool));
                        }
                        else if(yTool + Cube * i < Limit)
                        {
                            points.Add(new Point(xTool, yTool + Cube * i));
                        }
                    }
                    if (!atStart)
                    {
                        for (int i = 1; i <= 8; i++)
                        {
                            if (xTool - Cube * i > offset && yTool - Cube * i > offset)
                            {
                                points.Add(new Point(xTool - Cube * i, yTool));
                                points.Add(new Point(xTool, yTool - Cube * i));
                            }
                            else if(yTool - Cube * i > offset)
                            {
                                points.Add(new Point(xTool, yTool - Cube * i));
                            }
                        }
                    }
                }
                else
                {

                    for (int i = 1; i <= 8; i++)
                    {
                        points.Add(new Point(xTool - Cube * i, yTool));
                        points.Add(new Point(xTool, yTool - Cube * i));
                    }
                    if (!atStart)
                    {
                        for (int i = 1; i <= 8; i++)
                        {
                            if (xTool - Cube * i > offset)
                            {
                                points.Add(new Point(xTool + Cube * i, yTool));
                                points.Add(new Point(xTool, yTool + Cube * i));
                            }
                        }
                    }
                }
            }
            return points;
        }
    }
}
