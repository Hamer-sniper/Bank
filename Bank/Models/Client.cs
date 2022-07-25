using System;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client : Person, IPerson
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Surname = "Федоров";
            this.Name = "Федор";
            this.MiddleName = "Федорович";
            this.TelephoneNumber = "89187665577";
            this.Pasport = "0708 100600";
        }

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        public Client(string surname, string name, string middleName, string telephoneNumber, string pasport)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Surname = surname;
            this.Name = name;
            this.MiddleName = middleName;
            this.TelephoneNumber = telephoneNumber;
            this.Pasport = pasport;
        }
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
        #endregion


    }
}
