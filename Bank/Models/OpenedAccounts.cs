using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Interfaces;

namespace Bank.Models
{
    public class OpenedAccounts
    {
        #region Свойства
        /// <summary>
        /// Номер записи
        /// </summary>
        public string OpenedAccountID { get; set; } = string.Empty;

        /// <summary>
        /// ID счета
        /// </summary>
        public string AccountID { get; set; } = string.Empty;

        /// <summary>
        /// ID открывшего счет
        /// </summary>
        public string CounterpartyID { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время изменения записи
        /// </summary>
        public string ChangingDate { get; set; } = string.Empty;

        /// <summary>
        /// Сумма
        /// </summary>
        public string Sum { get; set; } = string.Empty;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="openedAccountID">Номер записи</param>
        /// <param name="accountID">ID счета</param>
        /// <param name="counterpartyID">ID открывшего счет</param>
        /// <param name="changingDate">Дата и время изменения записи</param>
        /// <param name="sum">Сумма</param>
        public OpenedAccounts(string openedAccountID, string accountID, string counterpartyID, string changingDate, string sum)
        {
            OpenedAccountID = openedAccountID;
            AccountID = accountID;
            CounterpartyID = counterpartyID;
            ChangingDate = changingDate;
            Sum = sum;
        }

        /// <summary>
        /// Конструктор с автоподстановкой даты и id
        /// </summary>
        /// <param name="accountID">ID счета</param>
        /// <param name="counterpartyID">ID открывшего счет</param>
        /// <param name="sum">Сумма</param>
        public OpenedAccounts(string accountID, string counterpartyID, string sum) :
            this(Guid.NewGuid().ToString(), accountID, counterpartyID, DateTime.Now.ToString(), sum) { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public OpenedAccounts() :
            this(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "400000") { }
        #endregion




        //#1 Получить Счет и Персону

        //#2 Создать экземпляр

        //#3 Записать в хмл








        //public Subject<> Person { get; set; }
        //public A Account { get; set; }

        //private OpenedAccounts(P person, A account)
        //{
        //    Person = person;
        //    Account = account;
        //}

        //public void Close()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Open(P concretePerson, A concreteAccount)
        //{
        //    var personAccount = new OpenedAccounts<P,A>(concretePerson, concreteAccount);
        //}

        //public void Transact()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
