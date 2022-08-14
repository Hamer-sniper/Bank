using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Interfaces;
using Bank.Data;

namespace Bank.Models
{
    public class OpenedAccounts : IOpenedAccounts
    {
        private readonly DataProvider _dataProvider = new DataProvider();

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
        public OpenedAccounts(string openedAccountID, string accountID, string counterpartyID, string changingDate)
        {
            OpenedAccountID = openedAccountID;
            AccountID = accountID;
            CounterpartyID = counterpartyID;
            ChangingDate = changingDate;
        }

        /// <summary>
        /// Конструктор с автоподстановкой даты и id
        /// </summary>
        /// <param name="accountID">ID счета</param>
        /// <param name="counterpartyID">ID открывшего счет</param>
        /// <param name="sum">Сумма</param>
        public OpenedAccounts(string accountID, string counterpartyID) :
            this(Guid.NewGuid().ToString(), accountID, counterpartyID, DateTime.Now.ToString())
        { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public OpenedAccounts() :
            this(Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
        { }
        #endregion

        #region Методы
        /// <summary>
        /// Открыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        /// <param name="sum">Сумма</param>
        public void Open(IAccount account, ICounterparty counterparty, string sum)
        {
            // Получить список созданных аккаунтов из XML.
            var openedAccounts = _dataProvider.ReadFromXmlOpenedAccounts();

            // Создать новый счет.
            var openNewAccount = new OpenedAccounts(account.Id, counterparty.Id);

            // Добавить новый счет в список.
            openedAccounts.Add(openNewAccount);

            // Записать в XML обновленный список счетов.
            _dataProvider.WriteToXmlOpenedAccounts(openedAccounts);
        }

        /// <summary>
        /// Закрыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        public void Close(IAccount account, ICounterparty counterparty)
        {
            // Получить список созданных аккаунтов из XML.
            var openedAccounts = _dataProvider.ReadFromXmlOpenedAccounts();

            // Найти счет для закрытия.
            var accountToDelete = openedAccounts.Find(x => x.AccountID == account.Id && x.CounterpartyID == counterparty.Id);

            // Если счет найден - удалить его из списка.
            if (accountToDelete != null)
            {
                // Удалить счет
                openedAccounts.Remove(accountToDelete);

                // Записать в XML обновленный список открытых счетов.
                _dataProvider.WriteToXmlOpenedAccounts(openedAccounts);
            }
        }

        /// <summary>
        /// Перевод с одного счета на другой
        /// </summary>
        /// <param name="accountFrom">С какого счета</param>
        /// <param name="accountTo">На какой счет</param>
        /// <param name="sum">Сумма</param>
        public void Transact(IAccount accountFrom, IAccount accountTo, string sum)
        {
            // Получить список созданных счетов из XML.
            var openedAccounts = _dataProvider.ReadFromXmlOpenedAccounts();

            // Найти созданные счета.
            var accountsExist = openedAccounts.FindAll(x => x.AccountID == accountFrom.Id || x.AccountID == accountTo.Id);

            // Если найдены оба счета.
            if (accountsExist.Count() == 2)
            {
                // Проверить на достаточность суммы для перевода
                double accountF, accountT = default(double);

                if (double.TryParse(accountFrom.Sum, out accountF) &&
                    double.TryParse(accountTo.Sum, out accountT) &&
                    accountF >= accountT)
                {
                    // Найти новые суммы.
                    accountFrom.Sum = (accountF - accountT).ToString();
                    accountTo.Sum = (accountT + accountF).ToString();

                    // Получить список счетов.
                    var accounts = _dataProvider.ReadFromXmLAccounts();

                    // Найти счета в списке счетов.
                    var aF = accounts.Find(x => x.Id == accountFrom.Id);
                    var aT = accounts.Find(x => x.Id == accountTo.Id);

                    // Удалить счета
                    if (aF != null)
                        accounts.Remove(aF);
                    if (aT != null)
                        accounts.Remove(aT);

                    // Добавить счета с новыми значениями
                    accounts.Add((Account)accountFrom);
                    accounts.Add((Account)accountTo);

                    // Записать в XML обновленный список счетов.
                    _dataProvider.WriteToXmlAccounts(accounts);
                }
            }

        }
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
