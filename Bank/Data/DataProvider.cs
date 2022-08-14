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
        private readonly static string _companiesFilePath = Environment.CurrentDirectory + @"\Data\Companies.xml";
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
                var account = new Account("Рубль", $"0505 1589 1789 104{i}", $"{i}00000");
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
                XElement sum = new XElement("sum", account.Sum);

                ak.Add(id, currency, number, sum);
                accounts.Add(ak);
            }
            accounts.Save(_accountsFilePath);
        }

        /// <summary>
        /// Чтение из xml (Счета)
        /// </summary>        
        /// <returns>accounts</returns>
        public List<Account> ReadFromXmLAccounts()
        {
            if (!File.Exists(_accountsFilePath)) AutoCreationAccounts();

            var accounts = new List<Account>();
            string xid = "", xcurrency = "", xnumber = "", xsum = "";

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
                        if (childnode.Name == "sum") xsum = childnode.InnerText;
                    }
                    var account = new Account(xid, xcurrency, xnumber, xsum);
                    accounts.Add(account);
                }
            }
            return accounts;
        }
        #endregion

        #region Физические
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
                XElement physical = new XElement("Physical");
                XElement id = new XElement("id", client.Id);
                XElement surname = new XElement("surname", client.Surname);
                XElement name = new XElement("name", client.Name);
                XElement middleName = new XElement("middleName", client.MiddleName);
                XElement telephoneNumber = new XElement("telephoneNumber", client.TelephoneNumber);
                XElement pasport = new XElement("pasport", client.Pasport);

                physical.Add(id, surname, name, middleName, telephoneNumber, pasport);
                persons.Add(physical);
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

        #region Юридические
        /// <summary>
        /// Автосоздание данных
        /// </summary>
        private void AutoCreationLegal()
        {
            var companies = new List<Company>();

            for (int i = 1; i < 10; i++)
            {
                var company = new Company($"Федоров {i}", $"Федор {i}", $"Федорович {i}", $"8918766557{i}", $"0708 10060{i}", $"1-02-66-05-60662-{i}", $"ИП");
                companies.Add(company);
            }
            WriteToXmlLegal(companies);
        }

        /// <summary>
        /// Запись в xml
        /// </summary>
        /// <param name="companiesList">Компании</param>
        public void WriteToXmlLegal(List<Company> companiesList)
        {
            XElement companies = new XElement("Companies");

            foreach (var company in companiesList)
            {
                XElement Legal = new XElement("Legal");
                XElement id = new XElement("id", company.Id);
                XElement surname = new XElement("surname", company.Surname);
                XElement name = new XElement("name", company.Name);
                XElement middleName = new XElement("middleName", company.MiddleName);
                XElement telephoneNumber = new XElement("telephoneNumber", company.TelephoneNumber);
                XElement pasport = new XElement("pasport", company.Pasport);
                XElement ogrn = new XElement("ogrn", company.OGRN);
                XElement type = new XElement("type", company.Type);

                Legal.Add(id, surname, name, middleName, telephoneNumber, pasport, ogrn, type);
                companies.Add(Legal);
            }
            companies.Save(_companiesFilePath);
        }

        /// <summary>
        /// Чтение из xml
        /// </summary>        
        /// <returns>companies</returns>
        public List<Company> ReadFromXmlLegal()
        {
            if (!File.Exists(_companiesFilePath)) AutoCreationLegal();

            var companies = new List<Company>();
            string xid = "", xsurname = "", xname = "", xmiddleName = "", xtelephoneNumber = "", xpasport = "", xogrn = "", xtype = "";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_companiesFilePath);

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
                        if (childnode.Name == "ogrn") xogrn = childnode.InnerText;
                        if (childnode.Name == "type") xtype = childnode.InnerText;
                    }
                    var company = new Company(xid, xsurname, xname, xmiddleName, xtelephoneNumber, xpasport, xogrn, xtype);
                    companies.Add(company);
                }
            }
            return companies;
        }
        #endregion

        #region Открытые счета
        /// <summary>
        /// Автосоздание данных (Открытые счета)
        /// </summary>
        private void AutoCreationOpenedAccounts()
        {
            var openedAccounts = new List<OpenedAccounts>();

            for (int i = 1; i < 10; i++)
            {
                var openedAccount = new OpenedAccounts(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                openedAccounts.Add(openedAccount);
            }
            WriteToXmlOpenedAccounts(openedAccounts);
        }

        /// <summary>
        /// Запись в xml (Открытые счета)
        /// </summary>
        /// <param name="openedAccountsList">Открытые счета</param>
        public void WriteToXmlOpenedAccounts(List<OpenedAccounts> openedAccountsList)
        {
            XElement openedAccounts = new XElement("OpenedAccounts");

            foreach (var openedAccount in openedAccountsList)
            {
                XElement openedxAccount = new XElement("OpenedAccount");
                XElement openedAccountID = new XElement("openedAccountID", openedAccount.OpenedAccountID);
                XElement accountID = new XElement("accountID", openedAccount.AccountID);
                XElement counterpartyID = new XElement("counterpartyID", openedAccount.CounterpartyID);
                XElement changingDate = new XElement("changingDate", openedAccount.ChangingDate);
                
                openedxAccount.Add(openedAccountID, accountID, counterpartyID, changingDate);
                openedAccounts.Add(openedxAccount);
            }
            openedAccounts.Save(_openedAccountsFilePath);
        }

        /// <summary>
        /// Чтение из xml (Открытые счета)
        /// </summary>        
        /// <returns>clients</returns>
        public List<OpenedAccounts> ReadFromXmlOpenedAccounts()
        {
            if (!File.Exists(_openedAccountsFilePath)) AutoCreationOpenedAccounts();

            var openedAccounts = new List<OpenedAccounts>();
            string xopenedAccountID = "", xaccountID = "", xcounterpartyID = "", xchangingDate = "", xsum = "";

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
                        if (childnode.Name == "openedAccountID") xopenedAccountID = childnode.InnerText;
                        if (childnode.Name == "accountID") xaccountID = childnode.InnerText;
                        if (childnode.Name == "counterpartyID") xcounterpartyID = childnode.InnerText;
                        if (childnode.Name == "changingDate") xchangingDate = childnode.InnerText;
                    }
                    var openedAccount = new OpenedAccounts(xopenedAccountID, xaccountID, xcounterpartyID, xchangingDate);
                    openedAccounts.Add(openedAccount);
                }
            }
            return openedAccounts;
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
