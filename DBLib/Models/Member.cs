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

        private List<int> approvedChatrooms = new List<int> { 1 }; //ID
        public Member(string username, string password, bool isOnline, List<int> approvedChatrooms)
        {
            Username = username;
            Password = password;
            IsOnline = IsOnline;
            this.approvedChatrooms = approvedChatrooms;
            //get highest LID ID from DB, change ID of class

            //refill approvedChatrooms
        }
        public Member(string username, string password)
        {
            Username = username;
            Password = password;
            IsOnline = true;
        }
        public void MakeRoom()
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
        public void AdminKicksMember(Member memberKicking, Guest personToKick)
        {
            //CurrentChatroom.RemoveMemberFromChatroom(memberKicking, personToKick);
        }
        public void AdminDeletesMessage(Message message, Chatroom chatroom)
        {
            //CurrentChatroom.RemoveMessage(message);
        }
        public void CreatorPromotesMember(Member member)
        {
            //CurrentChatroom.AddAdmin(member);
        }
        public void CreatorDemotesMember(Member member)
        {
            //CurrentChatroom.RemoveAdmin(member);
        }



    }
}
