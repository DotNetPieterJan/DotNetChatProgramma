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
        public Member Creator { get; private set; }
        public List<Member> Admins { get; private set; }
        public List<Guest> MembersInChatroom { get; private set; }
        public List<Message> Messages { get; private set; }

        public Chatroom(Member creator) : this(0, creator, new List<Member>(), new List<Guest>(), new List<Message>()) { }

        public Chatroom(int id, Member creator, List<Member> admins, List<Guest> memebersInChatroom, List<Message> messages)
        {
            ID = id;
            Creator = creator;
            Admins = new List<Member>();
            MembersInChatroom = new List<Guest>();
            Messages = new List<Message>();
        }

        public void AddAdmin(Member member)
        {
            Admins.Add(member);
        }
        public void RemoveAdmin(Member member)
        {
            Admins.Remove(member);
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
            MembersInChatroom.Add(guest);
        }
        public void RemoveMemberFromChatroom(Guest guest)
        {
            MembersInChatroom.Remove(guest);
        }
    }
}
