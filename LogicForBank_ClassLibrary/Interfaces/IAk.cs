using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForBank_ClassLibrary.Models;

namespace LogicForBank_ClassLibrary.Interfaces
{
    public interface IAk<out T>
        where T : Account
    {
        public T GetAccount(string currency, string sum, string counterparty);
    }
}
