﻿using System;
using System.Collections.Generic;
using Bank.Data;

namespace Bank.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Employee : Physical
    {
        DataProvider _dataProvider = new DataProvider();
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

        #region Сортировка
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
        private class SortBySurname : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                Client X = (Client)x;
                Client Y = (Client)y;

                return string.Compare(X.Surname, Y.Surname);
            }
        }

        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        private class SortByName : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                Client X = (Client)x;
                Client Y = (Client)y;

                return string.Compare(X.Name, Y.Name);
            }
        }

        /// <summary>
        /// Сортировка по критерию
        /// </summary>
        /// <param name="criterion"></param>
        /// <returns>List<Client></returns>
        public static IComparer<Client> SortedBy(SortedCriterion criterion)
        {
            if (criterion == SortedCriterion.Name) return new SortByName();
            else return new SortBySurname();
        }
        #endregion

        #region Методы
        /// <summary>
        /// Создать новую запись
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="middleName"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="pasport"></param>
        public void Create(string surname, string name, string middleName, string telephoneNumber, string pasport)
        {
            var client = new Client(surname, name, middleName, TelephoneNumber, string.IsNullOrWhiteSpace(pasport) ? "Паспорт не задан" : pasport);

            // Запись данных
            var clients = _dataProvider.ReadFromXml();
            clients.Add(client);
            _dataProvider.WriteToXml(clients);
        }

        /// <summary>
        /// Изменить всю информацию
        /// </summary>
        public void Update(Client emp)
        {
            var clients = _dataProvider.ReadFromXml();

            //var client = clients.Find(x => x.Id == emp.id);


            foreach (var client in clients)
            {
                if (client.Id != emp.Id)
                    continue;

                if (emp.Surname != client.Surname)
                    client.Surname = emp.Surname;
                if (emp.Name != client.Name)
                    client.Name = emp.Name;
                if (emp.MiddleName != client.MiddleName)
                    client.MiddleName = emp.MiddleName;
                if (emp.TelephoneNumber != client.TelephoneNumber)
                    client.TelephoneNumber = emp.TelephoneNumber;
                if (emp.Pasport != client.Pasport)
                    client.Pasport = string.IsNullOrWhiteSpace(emp.Pasport) ? "Паспорт не задан" : emp.Pasport;

                break;
            }
            _dataProvider.WriteToXml(clients);
        }

        /// <summary>
        /// Изменить всю информацию
        /// </summary>
        public void UpdateAll(List<Client> clients)
        {         
            _dataProvider.WriteToXml(clients);
        }
        #endregion
    }
}
