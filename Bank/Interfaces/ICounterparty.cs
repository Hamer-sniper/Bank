namespace Bank.Interfaces
{
    /// <summary>
    /// Общий интерфейс Физического/Юридического лица
    /// </summary>
    public interface ICounterparty
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }
}