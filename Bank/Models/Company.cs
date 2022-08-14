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
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        /// <param name="ogrn">ОГРН</param>
        /// <param name="type">ИП/ООО</param>
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

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        /// <param name="ogrn">ОГРН</param>
        /// <param name="type">ИП/ООО</param>
        public Company(string surname, string name, string middleName, string telephoneNumber, string pasport, string ogrn, string type) :
            this(Guid.NewGuid().ToString(), surname, name, middleName, telephoneNumber, pasport, ogrn, type) { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Company() :
            this("Федоров", "Федор", "Федорович", "89187665577", "0708 100600", "1-02-66-05-60662-0", "ООО") { }
        #endregion
    }
}
