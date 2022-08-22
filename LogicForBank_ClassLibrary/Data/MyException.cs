using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForBank_ClassLibrary.Data
{
    public class MyException : Exception
    {
        public string MyMessage { get; set; } = string.Empty;

        public MyException(string myMessage)
        {
            MyMessage = myMessage;
        }
    }
}
