using System;

namespace Bank.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Employee : Physical
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор со всеми полями
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        public Employee(string id, string surname, string name, string middleName, string telephoneNumber, string pasport)
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
        public Employee(string surname, string name, string middleName, string telephoneNumber, string pasport) :
            this(Guid.NewGuid().ToString(), surname, name, middleName, telephoneNumber, pasport) { }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Employee() :
            this("Ахвердов", "Андрей", "Александрович", "89187665566", "0708 100500") { }
        #endregion
    }
}
