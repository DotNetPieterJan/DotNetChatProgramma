﻿using System;
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
        public Member(string username, string password, bool isOnline)
        {

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
        public void AdminKicksMember(Member member)
        {

        }
        public void AdminDeletesMessage(Message message)
        {

        }
        public void CreatorPromotesMember(Member member)
        {

        }
        public void CreatorDemotesMember(Member member)
        {

        }



    }
}