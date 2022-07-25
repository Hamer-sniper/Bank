using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System;
using System.IO;
using Bank.Models;

namespace Bank.Data
{
    public class DataProvider
    {
        private readonly static string _clientsFilePath = Environment.CurrentDirectory + @"\Data\Clients.xml";
        private readonly static string _accountsFilePath = Environment.CurrentDirectory + @"\Data\Accounts.xml";
        private readonly static string _openedAccountsFilePath = Environment.CurrentDirectory + @"\Data\OpenedAccounts.xml";

        #region Счета

        /// <summary>
        /// Автосоздание данных (Счета)
        /// </summary>
        private void AutoCreationAccounts()
        {
            var accounts = new List<Account>();

            for (int i = 1; i < 10; i++)
            {
                var account = new Account("Рубль", $"0505 1589 1789 104{i}");
                accounts.Add(account);
            }
            WriteToXmlAccounts(accounts);
        }

        /// <summary>
        /// Запись в XML (Счета)
        /// </summary>
        /// <param name="accountsList">Счета</param>
        public void WriteToXmlAccounts(List<Account> accountsList)
        {
            XElement accounts = new XElement("Accounts");

            foreach (var account in accountsList)
            {
                XElement ak = new XElement("Account");
                XElement id = new XElement("id", account.Id);
                XElement currency = new XElement("currency", account.Currency);
                XElement number = new XElement("number", account.Number);

                ak.Add(id, currency, number);
                accounts.Add(ak);
            }
            accounts.Save(_accountsFilePath);
        }

        /// <summary>
        /// Чтение из xml (Счета)
        /// </summary>        
        /// <returns>accounts</returns>
        public List<Account> ReadFromXmAaccounts()
        {
            if (!File.Exists(_accountsFilePath)) AutoCreationAccounts();

            var accounts = new List<Account>();
            string xid = "", xcurrency = "", xnumber = "";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_accountsFilePath);

            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // обходим все дочерние узлы элемента
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "id") xid = childnode.InnerText;
                        if (childnode.Name == "currency") xcurrency = childnode.InnerText;
                        if (childnode.Name == "number") xnumber = childnode.InnerText;
                    }
                    var account = new Account(xid, xcurrency, xnumber);
                    accounts.Add(account);
                }
            }
            return accounts;
        }
        #endregion

        #region Персоны
        /// <summary>
        /// Автосоздание данных
        /// </summary>
        private void AutoCreation()
        {
            var clients = new List<Client>();           

            for (int i = 1; i < 10; i++)
            {
                var client = new Client($"Федоров {i}", $"Федор {i}", $"Федорович {i}", $"8918766557{i}", $"0708 10060{i}");
                clients.Add(client);
            }
            WriteToXml(clients);
        }

        /// <summary>
        /// Запись в xml
        /// </summary>
        /// <param name="clientsList">Клиенты</param>
        public void WriteToXml(List<Client> clientsList)
        {
            XElement persons = new XElement("Persons");

            foreach (var client in clientsList)
            {
                XElement person = new XElement("Person");
                XElement id = new XElement("id", client.Id);
                XElement surname = new XElement("surname", client.Surname);
                XElement name = new XElement("name", client.Name);
                XElement middleName = new XElement("middleName", client.MiddleName);
                XElement telephoneNumber = new XElement("telephoneNumber", client.TelephoneNumber);
                XElement pasport = new XElement("pasport", client.Pasport);

                person.Add(id, surname, name, middleName, telephoneNumber, pasport);
                persons.Add(person);
            }
            persons.Save(_clientsFilePath);
        }

        /// <summary>
        /// Чтение из xml
        /// </summary>        
        /// <returns>clients</returns>
        public List<Client> ReadFromXml()
        {
            if (!File.Exists(_clientsFilePath)) AutoCreation();

            var clients = new List<Client>();
            string xid = "", xsurname = "", xname = "", xmiddleName = "", xtelephoneNumber = "", xpasport = "";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_clientsFilePath);

            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // обходим все дочерние узлы элемента
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "id") xid = childnode.InnerText;
                        if (childnode.Name == "surname") xsurname = childnode.InnerText;
                        if (childnode.Name == "name") xname = childnode.InnerText;
                        if (childnode.Name == "middleName") xmiddleName = childnode.InnerText;
                        if (childnode.Name == "telephoneNumber") xtelephoneNumber = childnode.InnerText;
                        if (childnode.Name == "pasport") xpasport = childnode.InnerText;
                    }
                    var client = new Client(xid, xsurname, xname, xmiddleName, xtelephoneNumber, xpasport);
                    clients.Add(client);
                }
            }
            return clients;
        }
        #endregion

        #region Открытые счета
        /// <summary>
        /// Автосоздание данных (Открытые счета)
        /// </summary>
        private void AutoCreationOpenedAccounts()
        {
            //var clients = new List<Client>();

            //for (int i = 1; i < 10; i++)
            //{
            //    var client = new Client($"Федоров {i}", $"Федор {i}", $"Федорович {i}", $"8918766557{i}", $"0708 10060{i}");
            //    clients.Add(client);
            //}
            //WriteToXml(clients);
        }

        /// <summary>
        /// Запись в xml (Открытые счета)
        /// </summary>
        /// <param name="clientsList">Клиенты</param>
        public void WriteToXmlOpenedAccounts(List<Client> clientsList)
        {
            XElement openedAccounts = new XElement("OpenedAccounts");

            foreach (var client in clientsList)
            {
                XElement openedAccount = new XElement("OpenedAccount");
                XElement idPerson = new XElement("idPerson", client.Id);
                XElement idAccount = new XElement("idAccount", client.Surname);

                openedAccount.Add(idPerson, idAccount);
                openedAccounts.Add(openedAccount);
            }
            openedAccounts.Save(_openedAccountsFilePath);
        }

        /// <summary>
        /// Чтение из xml (Открытые счета)
        /// </summary>        
        /// <returns>clients</returns>
        public List<Client> ReadFromXmlOpenedAccounts()
        {
            //if (!File.Exists(_clientsFilePath)) AutoCreation();

            var clients = new List<Client>();
            //string xid = "", xsurname = "", xname = "", xmiddleName = "", xtelephoneNumber = "", xpasport = "";

            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(_clientsFilePath);

            //// получим корневой элемент
            //XmlElement? xRoot = xDoc.DocumentElement;
            //if (xRoot != null)
            //{
            //    // обход всех узлов в корневом элементе
            //    foreach (XmlElement xnode in xRoot)
            //    {
            //        // обходим все дочерние узлы элемента
            //        foreach (XmlNode childnode in xnode.ChildNodes)
            //        {
            //            if (childnode.Name == "id") xid = childnode.InnerText;
            //            if (childnode.Name == "surname") xsurname = childnode.InnerText;
            //            if (childnode.Name == "name") xname = childnode.InnerText;
            //            if (childnode.Name == "middleName") xmiddleName = childnode.InnerText;
            //            if (childnode.Name == "telephoneNumber") xtelephoneNumber = childnode.InnerText;
            //            if (childnode.Name == "pasport") xpasport = childnode.InnerText;
            //        }
            //        var client = new Client(xid, xsurname, xname, xmiddleName, xtelephoneNumber, xpasport);
            //        clients.Add(client);
            //    }
            //}
            return clients;
        }
        #endregion

        ///// <summary>
        ///// Создать новую запись
        ///// </summary>
        ///// <param name="usurname"></param>
        ///// <param name="uname"></param>
        ///// <param name="umiddleName"></param>
        ///// <param name="utelephoneNumber"></param>
        ///// <param name="upasport"></param>
        //public void Create(string usurname, string uname, string umiddleName, string utelephoneNumber, string upasport)
        //{
        //    var employee = new Employee()
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Surname = usurname,
        //        Name = uname,
        //        MiddleName = umiddleName,                
        //        TelephoneNumber = utelephoneNumber,
        //        Pasport = string.IsNullOrWhiteSpace(upasport) ? "Паспорт не задан" : upasport,

        //        DateTimeChange = DateTime.Now.ToString(),
        //        DataChanged = "All",
        //        TypeOfChanges = "Creation",
        //        Changer = "Manager"
        //    };
        //    // Запись в лог
        //    var changesLog = Work_with_log.ReadFromLogXml();
        //    changesLog.Add(employee);
        //    Work_with_log.AddToLogXmlFromList(changesLog);

        //    // Запись данных
        //    var employees = ReadFromXml();
        //    employees.Add(employee);
        //    AddToXmlFromList(employees); 
        //}

        ///// <summary>
        ///// Удалить запись
        ///// </summary>
        ///// <param name="emp"></param>
        //public void Delete(Employee emp)
        //{
        //    var employees = ReadFromXml();
        //    var tempEmployee = emp;

        //    foreach (var employee in employees)
        //    {
        //        if (employee.Id == emp.Id)
        //        {
        //            tempEmployee = employee;
        //            employees.Remove(tempEmployee);
        //            break;
        //        }
        //    }
        //    AddToXmlFromList(employees);
        //}
    }
}
