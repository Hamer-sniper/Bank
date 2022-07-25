
namespace Bank.Models
{
    /// <summary>
    /// Персона
    /// </summary>
    public abstract class Person
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
