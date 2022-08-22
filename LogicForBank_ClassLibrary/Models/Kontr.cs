using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForBank_ClassLibrary.Interfaces;

namespace LogicForBank_ClassLibrary.Models
{
    public class Kontr<T> : IKontr<T>
        where T : Counterparty
    {
        List<Counterparty> cp;

        public Kontr()
        {
            cp = new List<Counterparty>();
        }

        public void SetValueMethod(T args)
        {
            cp.Add(args);
        }

        void IKontr<T>.Transact(string from, string to, string sum)
        {
           Account _account = new Account();
        _account.Transact(from, to, sum);
        }
    }
}
