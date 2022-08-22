namespace LogicForBank_ClassLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс персоны
    /// </summary>
    public interface ILegal : ICounterparty
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
