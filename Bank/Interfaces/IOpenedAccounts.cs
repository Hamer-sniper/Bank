namespace Bank.Interfaces
{
    /// <summary>
    /// Интефейс открытых счетов
    /// </summary>
    public interface IOpenedAccounts
    {
        #region Свойства
        /// <summary>
        /// Номер записи
        /// </summary>
        public string OpenedAccountID { get; set; }

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
        #endregion

        #region Методы
        /// <summary>
        /// Открыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        /// <param name="sum">Сумма</param>
        public void Open(IAccount account, ICounterparty counterparty, string sum);

        /// <summary>
        /// Закрыть счет
        /// </summary>
        /// <param name="account">Счет</param>
        /// <param name="counterparty">Контрагент</param>
        public void Close(IAccount account, ICounterparty counterparty);

        /// <summary>
        /// Перевод с одного счета на другой
        /// </summary>
        /// <param name="accountFrom">С какого счета</param>
        /// <param name="accountTo">На какой счет</param>
        /// <param name="sum">Сумма</param>
        public void Transact(IAccount accountFrom, IAccount accountTo, string sum);
        #endregion
    }
}
