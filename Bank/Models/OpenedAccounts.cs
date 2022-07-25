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
        #region Свойства
        public P Person { get; set; }
        public A Account { get; set; }
        #endregion

        #region Конструкторы
        private OpenedAccounts(P person, A account)
        {
            Person = person;
            Account = account;
        }
        #endregion

        #region Методы
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
        #endregion
    }
}
