using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Data;
using Bank.Interfaces;

namespace Bank.Models
{
    public class Deposit : IAk<Account>
    {
        /// <summary>
        /// Открыть счет
        /// </summary>
        /// <param name="currency">Валюта</param>
        /// <param name="counterparty">Контрагент</param>
        /// <param name="sum">Сумма</param>
        public Account GetAccount(string currency, string sum, string counterparty)
        {
           return new Account(currency, sum, counterparty, "Да");
        }
    }
}
