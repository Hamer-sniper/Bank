namespace Bank.Interfaces
{
    /// <summary>
    /// Интерфейс персоны
    /// </summary>
    public interface IPhysical : ICounterparty
    {
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
    }
}
