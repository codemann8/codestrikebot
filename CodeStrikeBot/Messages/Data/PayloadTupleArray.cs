using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStrikeBot.Messages.Data
{
    public class PayloadTupleArray : PayloadObject
    {
        List<Tuple<string, PayloadObject>> list;

        public PayloadTupleArray()
        {
            list = new List<Tuple<string, PayloadObject>>();
        }

        public void Add(string key, PayloadObject value)
        {
            list.Add(new Tuple<string,PayloadObject>(key, value));
        }
    }
}
