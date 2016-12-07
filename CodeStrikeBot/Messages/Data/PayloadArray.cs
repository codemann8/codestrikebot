using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStrikeBot.Messages.Data
{
    public class PayloadArray : PayloadObject
    {
        List<PayloadObject> list;

        public PayloadArray()
        {
            list = new List<PayloadObject>();
        }
        
        public void Add(PayloadObject value)
        {
            list.Add(value);
        }
    }
}
