using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace DBLib.Managers
{
    class ChatManager
    {
        private static ConnectionStringSettings chatSettings = ConfigurationManager.ConnectionStrings["ChatroomConnection"];
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(chatSettings.ProviderName);

        internal DbConnection GetConnection()
        {
            DbConnection conChat = factory.CreateConnection();
            conChat.ConnectionString = chatSettings.ConnectionString;
            return conChat;
        }
    }
}
