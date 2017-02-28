using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    public class Guest
    {
        public int CurrentChatroom { get; set; } //ID
        public string Username { get; set; } //Guest : random generated username
        public Guest()
        {
            CurrentChatroom = 0;

        }
        public void Register() //converts to Member
        {

        }
        public void SendMessage(int currentChatroom, string message) //send message to CurrentChatroom
        {
            if (currentChatroom == CurrentChatroom)//no hax
            {

            }
        }
    }
}
