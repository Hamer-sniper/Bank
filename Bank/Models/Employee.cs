using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public class Employee : Person
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Перечисление критериев сортировки
        /// </summary>
        public enum SortedCriterion
        {
            Surname,
            Name
        }

        /// <summary>
        /// Сортировка по имени
        /// </summary>
        private class SortBySurname : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                Employee X = (Employee)x;
                Employee Y = (Employee)y;

                return string.Compare(X.Surname, Y.Surname);
            }
        }

        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        private class SortByName : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                Employee X = (Employee)x;
                Employee Y = (Employee)y;

                return string.Compare(X.Name, Y.Name);
            }
        }

        /// <summary>
        /// Сортировка по критерию
        /// </summary>
        /// <param name="criterion"></param>
        /// <returns>List<Employee></returns>
        public static IComparer<Employee> SortedBy(SortedCriterion criterion)
        {
            if (criterion == SortedCriterion.Name) return new SortByName();
            else return new SortBySurname();
        }
    }
}
