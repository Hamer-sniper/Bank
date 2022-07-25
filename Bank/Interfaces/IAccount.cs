using System;
using System.Collections.Generic;

namespace Bank.Interfaces
{
    /// <summary>
    /// Интефейс счета
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Открыть счет
        /// </summary>
        public void Open();

        /// <summary>
        /// Закрыть счет
        /// </summary>
        public void Close();

        /// <summary>
        /// Перевод с одного счета на другой
        /// </summary>
        public void Transact();
    }
}
