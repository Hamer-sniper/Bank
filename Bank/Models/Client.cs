using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Клиент (Физическое лицо)
    /// </summary>
    public class Client : Physical
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        public Client(string id, string surname, string name, string middleName, string telephoneNumber, string pasport)
        {
            this.Id = id;
            this.Surname = surname;
            this.Name = name;
            this.MiddleName = middleName;
            this.TelephoneNumber = telephoneNumber;
            this.Pasport = pasport;
        }

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        public Client(string surname, string name, string middleName, string telephoneNumber, string pasport) :
            this(Guid.NewGuid().ToString(), surname, name, middleName, telephoneNumber, pasport) { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Client() :
            this("Федоров", "Федор", "Федорович", "89187665577", "0708 100600") { }
        #endregion
    }
}
