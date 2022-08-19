using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models;

namespace Bank.Interfaces
{
    public interface IAk<out T>
        where T : Account
    {
        public T GetAccount(string currency, string sum, string counterparty);
    }
}
