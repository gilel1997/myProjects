using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Person
    {
        string fullName { get; set; }
        string phonNumber { get; set; }
        enum gender { male, female };
        int age { get; set; }
        string Email { get; set; }
        bool haveFastPassTicket { get; set; }

        public Person(string fullName, string phonNumber, string email, int age)
        {
            this.fullName = fullName;
            this.phonNumber = phonNumber;
            Email = email;
            this.age = age;
        }
        public void IfMaleOrFemale()
        {

        }
    }
}
