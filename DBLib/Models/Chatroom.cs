using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    public class Chatroom
    {
        public int ID { get; private set; }
        public int Creator { get; private set; } //ID creator
        public List<int> Admins { get; private set; } //ID members
        public List<int> MembersInChatroom { get; private set; } //ID members
        public List<Message> Messages { get; private set; }

        public Chatroom(Member creator, int id) : this(id, creator.ID, new List<int>(), new List<int>(), new List<Message>()) { }

        public Chatroom(int id, int creator, List<int> admins, List<int> memebersInChatroom, List<Message> messages)
        {
            ID = id;
            Creator = creator;
            Admins = admins;
            MembersInChatroom = memebersInChatroom;
            Messages = messages;
        }

        public void AddAdmin(Member member)
        {
            Admins.Add(member.ID);
        }
        public void RemoveAdmin(Member member)
        {
            Admins.Remove(member.ID);
        }
        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
        public void RemoveMessage(Message message)
        {
            Messages.Remove(message);
        }
        public void AddMemberToChatroom(Guest guest)
        {
            MembersInChatroom.Add(guest.ID);
        }
        public void RemoveMemberFromChatroom(Member kicking, Guest guestToKick)
        {
            if (kicking.ID == Creator)
            {
                MembersInChatroom.Remove(guestToKick.ID);
            }
            else if (Admins.Contains(kicking.ID))
            {
                MembersInChatroom.Remove(guestToKick.ID);
            }
        }
    }
}
