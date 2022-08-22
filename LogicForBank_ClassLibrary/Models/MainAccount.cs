using System;
using System.Collections.Generic;
using LogicForBank_ClassLibrary.Data;
using LogicForBank_ClassLibrary.Interfaces;

namespace LogicForBank_ClassLibrary.Models
{
    /// <summary>
    /// Общий класс счета (допустим банковкие, онлайн кошелек, вклад, копилка...)
    /// </summary>
    public class MainAccount
    {
        #region Свойства
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
        /// Валюта
        /// </summary>
        public string Currency { get; set; } = string.Empty;
        /// <summary>
        /// Номер счета
        /// </summary>
        public string Number { get; set; } = string.Empty;
        /// <summary>
        /// Сумма
        /// </summary>
        public string Sum { get; set; } = string.Empty;
        /// <summary>
        /// Депозитный
        /// </summary>
        public string Deposit { get; set; } = string.Empty;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>      
        /// <param name="sum">Сумма</param>
        public MainAccount(string accountID, string currency, string number, string sum, string counterpartyID, string changingDate, string deposit)
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
        public MainAccount(string currency, string sum, string counterpartyID, string deposit) :
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
        public MainAccount() :
            this("Рубль", "400000", Guid.NewGuid().ToString(), "Да")
        { }
        #endregion
    }
}
