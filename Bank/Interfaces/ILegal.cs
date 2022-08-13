using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Interfaces
{
    /// <summary>
    /// Интерфейс персоны
    /// </summary>
    public interface ILegal
    {
         /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// Паспорт
        /// </summary>
        public string Pasport { get; set; }
        /// <summary>
        /// ОГРН
        /// </summary>
        public string OGRN { get; set; }
        /// <summary>
        /// Тип (ИП, ООО)
        /// </summary>
        public string Type { get; set; }
    }
}
