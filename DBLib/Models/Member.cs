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
        public Member(int currentChatroom, int id, string username, string password, bool isOnline, List<int> approvedChatrooms) : base(currentChatroom, id, username, isOnline)
        {
            this.approvedChatrooms = approvedChatrooms;
        }
        public void MakeRoom()
        {

        }
        public void RemoveRoom()
        {

        }
        public void ChangeUsername(string newUsername)
        {
            Username = newUsername;
        }
        public void ChangePassword(string newPassword)
        {
            service.PasswordUpdateMember(this, newPassword);
        }
        public bool FindUser(Member member)
        {
            return false;
        }
        public void AdminAddsMember(Member member)
        {
            member.approvedChatrooms.Add(CurrentChatroom);
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
