using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Area
    {
        string name { get; set; }
        List<Attraction> attractions { get; set; }
        public Area(string name, List<Attraction> attractions)
        {
            this.name = name;
            this.attractions = attractions;
        }
        public void Search(string search)
        {

        }
        public void Sort()
        {

        }
        public List<Ride> FastPassRids()
        {
            return new List<Ride>();
        }
    }
}
