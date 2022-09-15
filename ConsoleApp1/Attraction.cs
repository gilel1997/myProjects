using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Attraction
    {
        string name { get; set; }
        List<Worker> workers { get; set; }
        int content { get; set; }
        bool isOpen { get; set; }

        public Attraction(string name, List<Worker> workers, int content)
        {
            this.name = name;
            this.workers = workers;
            this.content = content;
            this.isOpen = true;
        }
    }
}
