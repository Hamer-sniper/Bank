using System;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Компания (Юридическое лицо)
    /// </summary>
    public class Company : Legal
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Surname = "Федоров";
            this.Name = "Федор";
            this.MiddleName = "Федорович";
            this.TelephoneNumber = "89187665577";
            this.Pasport = "0708 100600";
            this.OGRN = "1-02-66-05-60662-0";
            this.Type = "ООО";
        }

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        public Company(string surname, string name, string middleName, string telephoneNumber, string pasport, string ogrn, string type)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Surname = surname;
            this.Name = name;
            this.MiddleName = middleName;
            this.TelephoneNumber = telephoneNumber;
            this.Pasport = pasport;
            this.OGRN = ogrn;
            this.Type = type;
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
        public Company(string id, string surname, string name, string middleName, string telephoneNumber, string pasport, string ogrn, string type)
        {
            this.Id = id;
            this.Surname = surname;
            this.Name = name;
            this.MiddleName = middleName;
            this.TelephoneNumber = telephoneNumber;
            this.Pasport = pasport;
            this.OGRN = ogrn;
            this.Type = type;
        }
        #endregion
    }
}
