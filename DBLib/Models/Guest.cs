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
        public int ID { get; set; }
        public Guest()
        {
            ID = GetAvailableNumber();
            CurrentChatroom = 0;
            Username = string.Format("Guest" + ID.ToString());
        }
        public void Register() //converts to Member
        {

        }
        public void SendMessage(int currentChatroom, string message) //send message to CurrentChatroom
        {
            if (currentChatroom == CurrentChatroom)//no hax
            {
                Message messageToPush = new Message(this, DateTime.Now, message);
            }
        }
        private int GetAvailableNumber()
        {
            Random rdn = new Random();
            return rdn.Next(1, 50000);
        }
    }
}
