using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Interfaces;

namespace Bank.Models
{
    public class OpenedAccounts<P, A> //: IAccount
    {
        public P Person { get; set; }
        public A Account { get; set; }

        private OpenedAccounts(P person, A account)
        {
            Person = person;
            Account = account;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Open(P concretePerson, A concreteAccount)
        {

            var personAkt = new OpenedAccounts<P,A>(concretePerson, concreteAccount);
        }

        public void Transact()
        {
            throw new NotImplementedException();
        }
    }
}
