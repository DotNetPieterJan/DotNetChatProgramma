using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    public class Member : Guest
    {
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        private List<Chatroom> approvedChatrooms = new List<Chatroom>();
        public Member(string username, string password, bool isOnline)
        {
            //get highest LID ID from DB, change ID of class

            //refill approvedChatrooms
        }
        public void MakeRoom(Member member)
        {

        }
        public void ChangePassword(Member member)
        {

        }
        public bool FindUser(Member member)
        {
            return false;
        }
        public void AdminAddsMember(Member member)
        {

        }
        public void AdminKicksMember(Member memberKicking, Member memberToKick)
        {
            CurrentChatroom.RemoveMemberFromChatroom(memberKicking, memberToKick);
        }
        public void AdminDeletesMessage(Message message, Chatroom chatroom)
        {
            CurrentChatroom.RemoveMessage(message);
        }
        public void CreatorPromotesMember(Member member)
        {
            CurrentChatroom.AddAdmin(member);
        }
        public void CreatorDemotesMember(Member member)
        {
            CurrentChatroom.RemoveAdmin(member);
        }



    }
}
