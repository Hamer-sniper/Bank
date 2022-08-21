using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Bank.Data;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Банковские счета
    /// </summary>
    public class Account : MainAccount, IAccount
    {
        private readonly DataProvider _dataProvider = new DataProvider();

        // Событие изменения счета.
        public static event Action<Account, string> OnAccountChanged;

        #region Конструкторы
        static Account()
        {
            OnAccountChanged += WriteLogToTxt.Account_OnAccountChanged;
        }

        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>      
        /// <param name="sum">Сумма</param>
        public Account(string accountID, string currency, string number, string sum, string counterpartyID, string changingDate, string deposit)
        {
            this.AccountID = accountID;
            this.Currency = currency;
            this.Number = number;
            this.Sum = sum;
            this.CounterpartyID = counterpartyID;
            this.ChangingDate = changingDate;
            this.Deposit = deposit;
        }

        /// <summary>
        /// Конструктор с автоподстановкой id и даты и номера
        /// </summary>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>
        public Account(string currency, string sum, string counterpartyID, string deposit) :
            this(Guid.NewGuid().ToString(),
                currency,
                $"{new Random().Next(999, 10000).ToString()} {new Random().Next(999, 10000).ToString()} {new Random().Next(999, 10000).ToString()} {new Random().Next(999, 10000).ToString()}",
                sum,
                counterpartyID,
                DateTime.Now.ToString(),
                deposit)
        { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Account() :
            this("Рубль", "400000", Guid.NewGuid().ToString(), "Да")
        { }
        #endregion

        #region Методы
        /// <summary>
        /// Открыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        public void Open(Account account)
        {
            // Получить список созданных аккаунтов из XML.
            var accounts = _dataProvider.ReadFromXmLAccounts();

            // Добавить новый счет в список.
            accounts.Add(account);

            // Записать в XML обновленный список счетов.
            _dataProvider.WriteToXmlAccounts(accounts);

            // Событие изменения счета.
            OnAccountChanged(account, "Открыт новый счет");
        }

        /// <summary>
        /// Закрыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        public void Close(string account, string counterparty)
        {
            // Получить список созданных аккаунтов из XML.
            var accounts = _dataProvider.ReadFromXmLAccounts();

            // Найти счет для закрытия.
            var accountToDelete = accounts.Find(x => x.AccountID == account && x.CounterpartyID == counterparty);

            // Если счет найден - удалить его из списка.
            if (accountToDelete != null)
            {
                // Удалить счет
                accounts.Remove(accountToDelete);

                // Записать в XML обновленный список открытых счетов.
                _dataProvider.WriteToXmlAccounts(accounts);

                // Событие изменения счета.
                OnAccountChanged(accountToDelete, "Счет закрыт");
            }
        }

        /// <summary>
        /// Перевод с одного счета на другой
        /// </summary>
        /// <param name="accountFrom">С какого счета</param>
        /// <param name="accountTo">На какой счет</param>
        /// <param name="sum">Сумма</param>
        public void Transact(string accountFrom, string accountTo, string sum)
        {
            // Получить список созданных счетов из XML.
            var accounts = _dataProvider.ReadFromXmLAccounts();

            // Конвертация в Double.
            double accountF, accountT, sumFT = default(double);

            // Найти счета в списке счетов.
            var aF = accounts.Find(x => x.AccountID == accountFrom);
            var aT = accounts.Find(x => x.AccountID == accountTo);

            if ((aF != null && aT != null) &&
                double.TryParse(aF.Sum, out accountF) &&
                double.TryParse(aT.Sum, out accountT) &&
                double.TryParse(sum, out sumFT) &&
                aF.Currency == aT.Currency &&
                accountF >= sumFT)
            {
                // Найти новые суммы.
                aF.Sum = (accountF - sumFT).ToString();
                aT.Sum = (accountT + sumFT).ToString();

                // Записать в XML обновленный список счетов.
                _dataProvider.WriteToXmlAccounts(accounts);

                // Событие изменения счета.
                OnAccountChanged(aF, "Произведен перевод");
            }
        }
        #endregion
    }
}
