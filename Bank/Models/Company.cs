using System;
using System.Collections.Generic;
using Bank.Data;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Компания (Юридическое лицо)
    /// </summary>
    public class Company : Legal
    {
        DataProvider _dataProvider = new DataProvider();

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
        private class SortBySurname : IComparer<Company>
        {
            public int Compare(Company x, Company y)
            {
                Company X = (Company)x;
                Company Y = (Company)y;

                return string.Compare(X.Surname, Y.Surname);
            }
        }

        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        private class SortByName : IComparer<Company>
        {
            public int Compare(Company x, Company y)
            {
                Company X = (Company)x;
                Company Y = (Company)y;

                return string.Compare(X.Name, Y.Name);
            }
        }

        /// <summary>
        /// Сортировка по критерию
        /// </summary>
        /// <param name="criterion"></param>
        /// <returns>List<Client></returns>
        public static IComparer<Company> SortedBy(SortedCriterion criterion)
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
        public void Create(string surname, string name, string middleName, string telephoneNumber, string pasport, string ogrn, string type)
        {
            var company = new Company(surname, name, middleName, telephoneNumber, string.IsNullOrWhiteSpace(pasport) ? "Паспорт не задан" : pasport, ogrn, type);

            // Запись данных
            var companies = _dataProvider.ReadFromXmlLegal();
            companies.Add(company);
            _dataProvider.WriteToXmlLegal(companies);
        }

        /// <summary>
        /// Удалить запись
        /// </summary>
        public void Delete(Company cmp)
        {
            var clients = _dataProvider.ReadFromXmlLegal();
            var company = clients.Find(x => x.Id == cmp.Id);

            if (company != null)
                clients.Remove(company);

            _dataProvider.WriteToXmlLegal(clients);
        }

        /// <summary>
        /// Изменить всю информацию
        /// </summary>
        public void Update(Company cmp)
        {
            var companies = _dataProvider.ReadFromXmlLegal();

            foreach (var company in companies)
            {
                if (company.Id != cmp.Id)
                    continue;

                if (cmp.Surname != company.Surname)
                    company.Surname = cmp.Surname;
                if (cmp.Name != company.Name)
                    company.Name = cmp.Name;
                if (cmp.MiddleName != company.MiddleName)
                    company.MiddleName = cmp.MiddleName;
                if (cmp.TelephoneNumber != company.TelephoneNumber)
                    company.TelephoneNumber = cmp.TelephoneNumber;
                if (cmp.Pasport != company.Pasport)
                    company.Pasport = string.IsNullOrWhiteSpace(cmp.Pasport) ? "Паспорт не задан" : cmp.Pasport;

                break;
            }
            _dataProvider.WriteToXmlLegal(companies);
        }

        /// <summary>
        /// Изменить всю информацию
        /// </summary>
        public void UpdateAll(List<Company> companies)
        {
            _dataProvider.WriteToXmlLegal(companies);
        }
        #endregion
    }
}
