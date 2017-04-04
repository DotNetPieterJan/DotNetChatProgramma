using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLib.Managers;
using DBLib.Models;
using System.Data;
using System.Data.Common;

namespace DBLib.Services
{
    public class ChatroomsService
    {
        ChatManager manager = new ChatManager();

        internal int GetHighestUserID()
        {
            int id = 0;
            using (DbConnection conChat = manager.GetConnection())
            {
                using (DbCommand comGetHighestUserId = conChat.CreateCommand())
                {
                    comGetHighestUserId.CommandText = "SELECT MAX(chatuser_id) FROM ChatUser;";
                    conChat.Open();
                    id = (int)comGetHighestUserId.ExecuteScalar();
                }
            }
            return id + 1;
        }

        internal void SchrijfGuestWeg(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
