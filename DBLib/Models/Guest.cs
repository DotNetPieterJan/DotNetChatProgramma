using System;
using System.Collections.Generic;
using DBLib.Services;

namespace DBLib.Models
{
    public class Guest
    {
        ChatroomsService service = new ChatroomsService();

        public int CurrentChatroom { get; set; } //ID
        public string Username { get; set; } //Guest : random generated username
        public int ID { get; private set; }
        public bool IsOnline { get; set; }
        public Guest(int currentChatroom, int id, string username, bool isOnline)
        {
            CurrentChatroom = 1;
            ID = id;
            Username = username;
            IsOnline = isOnline;
        }
        public Guest()
        {
            ID = service.GetHighestUserID();
            CurrentChatroom = 1;
            Username = string.Format("Guest" + ID.ToString());
            IsOnline = true;
        }
        public void Register() //converts to Member
        {
            Console.WriteLine("Input your new username: ");
            string username = Console.ReadLine().Trim();
            Console.WriteLine("Input your new password: ");
            string password = Console.ReadLine().Trim();
            Member newMember = new Member(CurrentChatroom, ID, username, password, IsOnline, new List<int> { 1 });
        }
        public void SendMessage(string message) //send message to CurrentChatroom
        {
            Message messageToPush = new Message(this, DateTime.Now, message);
            //CurrentChatroom.AddMessage(messageToPush);
        }

        public static void CreateNewGuest()
        {
            ChatroomsService service = new ChatroomsService();
            Guest guest = new Guest();
            service.SchrijfGuestWeg(guest);
        }
    }
}
