using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Restaurant : Attraction
    {
        Dictionary<string,int> menu;

        public Restaurant(string name, int content, List<Worker> workers, Dictionary<string, int>    menu)
        : base(name, workers, content)
        {
            this.menu = menu;
        }
    }
}
