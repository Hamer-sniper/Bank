using System;

namespace Bank.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Employee : Person
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Surname = "Ахвердов";
            this.Name = "Андрей";
            this.MiddleName = "Александрович";
            this.TelephoneNumber = "89187665566";
            this.Pasport = "0708 100500";
        }

        /// <summary>
        /// Конструктор с автоподстановкой id
        /// </summary>        
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="telephoneNumber">Номер телефона</param>
        /// <param name="pasport">Паспорт</param>
        public Employee(string surname, string name, string middleName, string telephoneNumber, string pasport)
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
        #endregion











        //    /// <summary>
        //    /// Перечисление критериев сортировки
        //    /// </summary>
        //    public enum SortedCriterion
        //    {
        //        Surname,
        //        Name
        //    }

        //    /// <summary>
        //    /// Сортировка по имени
        //    /// </summary>
        //    private class SortBySurname : IComparer<Employee>
        //    {
        //        public int Compare(Employee x, Employee y)
        //        {
        //            Employee X = (Employee)x;
        //            Employee Y = (Employee)y;

        //            return string.Compare(X.Surname, Y.Surname);
        //        }
        //    }

        //    /// <summary>
        //    /// Сортировка по фамилии
        //    /// </summary>
        //    private class SortByName : IComparer<Employee>
        //    {
        //        public int Compare(Employee x, Employee y)
        //        {
        //            Employee X = (Employee)x;
        //            Employee Y = (Employee)y;

        //            return string.Compare(X.Name, Y.Name);
        //        }
        //    }

        //    /// <summary>
        //    /// Сортировка по критерию
        //    /// </summary>
        //    /// <param name="criterion"></param>
        //    /// <returns>List<Employee></returns>
        //    public static IComparer<Employee> SortedBy(SortedCriterion criterion)
        //    {
        //        if (criterion == SortedCriterion.Name) return new SortByName();
        //        else return new SortBySurname();
        //    }
    }
}
