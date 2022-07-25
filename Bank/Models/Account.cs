using System;
using System.Collections.Generic;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Счет
    /// </summary>
    public class Account
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
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Account()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Currency = "Рубль";
            this.Number = "0505 1589 1789 1045";
        }

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>
        public Account(string currency, string number)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Currency = currency;
            this.Number = number;
        }

        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="currency">Фамилия</param>
        /// <param name="number">Имя</param>
        public Account(string id, string currency, string number)
        {
            this.Id = id;
            this.Currency = currency;
            this.Number = number;
        }
        #endregion
    }
}
