using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   public class Worker : Person
    {
        
        int workerNumber { get; set; }
        int seleryPerHour { get; set; }
        int hours { get; set; }

        public Worker(string fullName, string phonNumber, int age, string email, int workerNumber, int hours)
           : base(fullName, phonNumber, email, age)
        {
            this.workerNumber = workerNumber;
            this.hours = hours;
        }
        public int SeleryMonth()
        {
            return 0;
        }
    }
}
