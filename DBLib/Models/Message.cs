using System;

namespace DBLib.Models
{
    public class Message
    {
        public Guest Sender { get; private set; }
        public DateTime DateSend { get; private set; }
        public string SentMessage { get; private set; }

        public Message (Guest sender, DateTime dateSend, string sentMessage)
        {
            Sender = sender;
            DateSend = dateSend;
            SentMessage = sentMessage;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}:\n{2}", DateSend.ToShortDateString(), Sender, SentMessage);
        }
    }
}