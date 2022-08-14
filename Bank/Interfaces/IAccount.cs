namespace Bank.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Номер счета
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public string Sum { get; set; }
    }
}