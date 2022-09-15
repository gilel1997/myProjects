using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Ride : Attraction
    {
        
        int serialNumber { get; set; }
        bool isFastPassAllow { get; set; }
        uint fastPassTicket { get; set; }
        int waitInLine { get; set; }


        public Ride(string name, int serialNumber, int content, List<Worker> workers, bool isFastPassAllow)
        : base(name, workers, content)
        {
            this.serialNumber = serialNumber;
            this.isFastPassAllow = isFastPassAllow;
            if(isFastPassAllow)
            {
                this.fastPassTicket = 100;
            }
            else
            {
                this.fastPassTicket = 0;
            }
        }
        public void RegisterFastPassTicket(User user)
        {

        }
        public bool IsFastPassTicketLeft()
        {
            return true;
        }

    }
}
