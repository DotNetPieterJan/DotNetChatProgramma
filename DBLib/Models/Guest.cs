using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    class Guest
    {
        public int CurrentChatroom { get; set; } //ID
        public string Username { get; set; } //Guest : random generated username
        public void Register() //converts to Member
        {

        }
        public void SendMessage(int currentChatroom) //send message to CurrentChatroom
        {
            if (currentChatroom == CurrentChatroom)//no hax
            {

            }
        }
    }
}
