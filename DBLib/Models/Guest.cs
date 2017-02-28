using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    public class Guest
    {
        public Chatroom CurrentChatroom { get; set; } //ID
        public string Username { get; set; } //Guest : random generated username
        public int ID { get; set; }
        public Guest()
        {
            ID = GetAvailableNumber();
            //select global chatroom

            Username = string.Format("Guest" + ID.ToString());
        }
        public void Register() //converts to Member
        {
            Console.WriteLine("");
            //inform DB that this ID is good to clear


        }
        public void SendMessage(Chatroom currentChatroom, string message) //send message to CurrentChatroom
        {
            if (currentChatroom == CurrentChatroom)//no hax
            {
                Message messageToPush = new Message(this, DateTime.Now, message);
                //push to chatroom
            }
        }
        private int GetAvailableNumber()
        {
            Random rdn = new Random();
            return rdn.Next(1, 50000);
        }
    }
}
