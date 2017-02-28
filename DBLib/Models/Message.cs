using System;

namespace DBLib.Models
{
    class Message
    {
        public Guest Sender { get; private set; }
        public DateTime DateSend { get; private set; }
        public string SendedMessage { get; private set; }

        public Message (Guest sender, DateTime dateSend, string sendedMessage)
        {
            Sender = sender;
            DateSend = dateSend;
            SendedMessage = sendedMessage;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}:\n{2}", DateSend.ToShortDateString(), Sender, SendedMessage);
        }
    }
}