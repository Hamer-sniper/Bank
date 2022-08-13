﻿using System;
using System.Collections.Generic;

namespace Bank.Interfaces
{
    /// <summary>
    /// Интефейс субъекта (Физическое/Юридическое лицо)
    /// </summary>
    public interface ISubject<T>
    {
        /// <summary>
        /// Контрагент
        /// </summary>
        public T Counterparty { get; set; }

    }
}
