using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Interfaces;

namespace Bank.Models
{
    /// <summary>
    /// Физическое лицо
    /// </summary>
    public abstract class Physical : IPhysical
    {
        #region Свойства
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; } = string.Empty;
        /// <summary>
        /// Телефон
        /// </summary>
        public string TelephoneNumber { get; set; } = string.Empty;
        /// <summary>
        /// Паспорт
        /// </summary>
        public string Pasport { get; set; } = string.Empty;
        #endregion
    }
}
