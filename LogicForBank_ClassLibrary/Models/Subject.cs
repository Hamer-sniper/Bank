using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForBank_ClassLibrary.Data;
using LogicForBank_ClassLibrary.Interfaces;

namespace LogicForBank_ClassLibrary.Models
{
    /// <summary>
    /// Субъект (контрагент)
    /// </summary>
    /// <typeparam name="T">Физическое/Юридическое лицо</typeparam>
    public class Subject<T> : ISubject<T>
    {
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
