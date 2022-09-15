using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class User
    {
        string username { get; set; }
        Person person { get; set; }

        public User(string username, Person person)
        {

        }
        public void singUp(string username, Person person)
        {

        }
        public void singin(string username)
        {

        }
        public bool IsUsernameValid(string username)
        {
            return true;
        }
        public void WriteToDB()
        {

        }
        public void ReadFromDB()
        {

        }

    }
}
