using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;

namespace WriteLogToTxtClassLibrary
{
    public class WriteLogToTxtClassLibrary
    {
        public static void WriteToTxt(string path, string text)
        {
            File.AppendAllText(path, text);
        }
    }
}