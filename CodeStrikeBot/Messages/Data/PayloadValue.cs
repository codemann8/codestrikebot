using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStrikeBot.Messages.Data
{
    public class PayloadValue : PayloadObject
    {
        Object value;

        public PayloadValue()
        {

        }

        public void Set(Object value)
        {
            this.value = value;
        }
    }
}
