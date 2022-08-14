using System;
using System.Collections.Generic;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Счет
    /// </summary>
    public class Account : IAccount
    {
        #region Свойства
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
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
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>      
        /// <param name="sum">Сумма</param>
        public Account(string id, string currency, string number, string sum)
        {
            this.Id = id;
            this.Currency = currency;
            this.Number = number;
            this.Sum = sum;
        }

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>
        public Account(string currency, string number, string sum) : 
            this(Guid.NewGuid().ToString(), currency, number, sum) { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Account() :
            this("Рубль", "0505 1589 1789 1045", "400000") { }
        #endregion
    }
}
