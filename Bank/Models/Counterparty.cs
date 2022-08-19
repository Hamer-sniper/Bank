using Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Counterparty : ICounterparty
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
