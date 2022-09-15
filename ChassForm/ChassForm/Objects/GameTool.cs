using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChassForm.Objects
{
    public class GameTool
    {
        public Colors color { get; set; }
        public string name { get; set; }
        Image Image { get; set; }
        public int Limit { get; set; }
        public GameTool()
        {

        }
        public GameTool(Colors color, string name, Image image)
        {
            this.color = color;
            this.name = name;
            this.Image = image;
            Limit = 477;
        }
        public virtual List<Point> Move(string name, int xTool, int yTool, int Cube, bool atStart,int offset)
        {
            return new List<Point>();
        }
        public virtual Point Eat()
        {
            return new Point();
        }
    }
}
