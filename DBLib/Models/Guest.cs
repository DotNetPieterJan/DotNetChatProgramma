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
        public Guest(int currentChatroom, string username, int id)
        {
            CurrentChatroom = currentChatroom;
            Username = username;
            ID = id;
        }
        public Guest()
        {
            ID = GetAvailableNumber();
            //select global chatroom

            Username = string.Format("Guest" + ID.ToString());
        }
        public void Register() //converts to Member
        {
            Console.WriteLine("Input your new username: ");
            string username = Console.ReadLine().Trim();
            Console.WriteLine("Input your new password :");
            string password = Console.ReadLine().Trim();
            Member newMember = new Member(username, password, true);
            //inform DB that this ID is good to clear
            //delete this guest from guestdb
        }
        public void SendMessage(string message) //send message to CurrentChatroom
        {
            Message messageToPush = new Message(this, DateTime.Now, message);
            //CurrentChatroom.AddMessage(messageToPush);

        }
        private int GetAvailableNumber()
        {
            Random rdn = new Random();
            return rdn.Next(1, 50000);
        }
    }
}
