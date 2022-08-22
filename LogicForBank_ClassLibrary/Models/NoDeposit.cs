using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForBank_ClassLibrary.Data;
using LogicForBank_ClassLibrary.Interfaces;

namespace LogicForBank_ClassLibrary.Models
{
    public class NoDeposit : IAk<Account>
    {
        /// <summary>
        /// Открыть счет
        /// </summary>
        /// <param name="currency">Валюта</param>
        /// <param name="counterparty">Контрагент</param>
        /// <param name="sum">Сумма</param>
        public Account GetAccount(string currency, string sum, string counterparty)
        {
            return new Account(currency, sum, counterparty, "Нет");
        }
    }
}
