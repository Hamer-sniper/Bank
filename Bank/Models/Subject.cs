using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Data;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Субъект (контрагент)
    /// </summary>
    /// <typeparam name="T">Физическое/Юридическое лицо</typeparam>
    public class Subject<T> : ISubject<T>
    {
        private readonly DataProvider _dataProvider = new DataProvider();

        /// <summary>
        /// Контрагент
        /// </summary>
        public T Counterparty { get; set; }

        public Subject(T Value)
        {
            Counterparty = Value;
        }

        public T GetSubject()
        {
            return Counterparty;
        }
        public string GetSubjectID()
        {
            var subj = (ICounterparty)Counterparty;
            
            return subj.Id;
        }
    }
}
