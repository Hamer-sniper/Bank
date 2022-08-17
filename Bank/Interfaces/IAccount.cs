namespace Bank.Interfaces
{
    public interface IAccount
    {
        #region Свойства
        /// <summary>
        /// ID счета
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// ID открывшего счет
        /// </summary>
        public string CounterpartyID { get; set; }

        /// <summary>
        /// Дата и время изменения записи
        /// </summary>
        public string ChangingDate { get; set; }

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
        #endregion

        #region Методы
        /// <summary>
        /// Открыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        /// <param name="sum">Сумма</param>
        public void Open(string account, string counterparty, string sum);

        /// <summary>
        /// Закрыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        public void Close(string account, string counterparty);

        /// <summary>
        /// Перевод с одного счета на другой
        /// </summary>
        /// <param name="accountFrom">С какого счета</param>
        /// <param name="accountTo">На какой счет</param>
        /// <param name="sum">Сумма</param>
        public void Transact(string accountFrom, string accountTo, string sum);
        #endregion
    }
}