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
            using (DbConnection conChat = manager.GetConnection())
            {
                using (DbCommand comSchrijfGuestWeg = conChat.CreateCommand())
                {
                    comSchrijfGuestWeg.CommandType = CommandType.Text;
                    comSchrijfGuestWeg.CommandText = "INSERT [Members] ([MemberId], [Username], [Password], [IsOnline]) VALUES (@id, @username, @password, @isonline)";

                    DbParameter parGuestId = comSchrijfGuestWeg.CreateParameter();
                    parGuestId.ParameterName = "@id";
                    parGuestId.Value = guest.ID;
                    comSchrijfGuestWeg.Parameters.Add(parGuestId);

                    DbParameter parGuestUsername = comSchrijfGuestWeg.CreateParameter();
                    parGuestUsername.ParameterName = "@username";
                    parGuestUsername.Value = guest.Username;
                    comSchrijfGuestWeg.Parameters.Add(parGuestUsername);

                    DbParameter parGuestPassword = comSchrijfGuestWeg.CreateParameter();
                    parGuestPassword.ParameterName = "@password";
                    parGuestPassword.Value = null;
                    comSchrijfGuestWeg.Parameters.Add(parGuestPassword);

                    DbParameter parGuestOnline = comSchrijfGuestWeg.CreateParameter();
                    parGuestOnline.ParameterName = "@online";
                    parGuestOnline.Value = guest.IsOnline;
                    comSchrijfGuestWeg.Parameters.Add(parGuestOnline);

                    conChat.Open();
                    comSchrijfGuestWeg.ExecuteNonQuery();
                }
            }
        }

        internal void CreateMember(Member member)
        {
            using (DbConnection conChat = manager.GetConnection())
            {
                using (DbCommand comCreateMember = conChat.CreateCommand())
                {
                    comCreateMember.CommandType = CommandType.Text;
                    comCreateMember.CommandText = "UPDATE Members SET Username = @username AND Password = @password WHERE MemberId = @id";

                    DbParameter parMemberId = comCreateMember.CreateParameter();
                    parMemberId.ParameterName = "@id";
                    parMemberId.Value = member.ID;
                    comCreateMember.Parameters.Add(parMemberId);

                    DbParameter parMemberUsername = comCreateMember.CreateParameter();
                    parMemberUsername.ParameterName = "@username";
                    parMemberUsername.Value = member.Username;
                    comCreateMember.Parameters.Add(parMemberUsername);

                    DbParameter parMemberPassword = comCreateMember.CreateParameter();
                    parMemberPassword.ParameterName = "@password";
                    parMemberPassword.Value = member.Password;
                    comCreateMember.Parameters.Add(parMemberPassword);

                    conChat.Open();
                    comCreateMember.ExecuteNonQuery();
                }
            }
        }

        internal bool PasswordUpdateMember(Member member, string newPassword)
        {
            using (DbConnection conChat = manager.GetConnection())
            {
                conChat.Open();
                using (DbTransaction traChangePassword = conChat.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (DbCommand comChangePassword = conChat.CreateCommand())
                    {
                        comChangePassword.Transaction = traChangePassword;
                        comChangePassword.CommandType = CommandType.Text;
                        comChangePassword.CommandText = "UPDATE Members SET Password = @password WHERE MemberId = @id";

                        DbParameter parMemberId = comChangePassword.CreateParameter();
                        parMemberId.ParameterName = "@id";
                        parMemberId.Value = member.ID;
                        comChangePassword.Parameters.Add(parMemberId);

                        DbParameter parMemberPassword = comChangePassword.CreateParameter();
                        parMemberPassword.ParameterName = "@password";
                        parMemberPassword.Value = member.Password;
                        comChangePassword.Parameters.Add(parMemberPassword);

                        if (comChangePassword.ExecuteNonQuery() == 0)
                        {
                            traChangePassword.Rollback();
                            return false;
                        }
                        traChangePassword.Commit();
                        return true;
                    }
                }
            }
        }
    }
}
