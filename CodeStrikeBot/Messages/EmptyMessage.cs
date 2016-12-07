using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStrikeBot.Messages
{
    public class EmptyMessage : Message
    {
        public EmptyMessage(Message message) 
            : base(message)
        {
            this.Type = MessageType.Blank;
        }
    }
}
