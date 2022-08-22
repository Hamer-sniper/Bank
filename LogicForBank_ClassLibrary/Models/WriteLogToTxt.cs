using System;
using System.IO;

namespace LogicForBank_ClassLibrary.Models
{
    public class WriteLogToTxt
    {
        private readonly static string _logFilePath = Environment.CurrentDirectory + @"\Data\Log.txt";
        
        /// <summary>
        /// Метод по работе с логом (event)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="reason"></param>
        public static void Account_OnAccountChanged(Account account, string reason)
        {
            File.AppendAllText(_logFilePath, $"\n{DateTime.Now.ToString()} - Произошли изменения со счетом {account.AccountID} у пользователя {account.CounterpartyID} на сумму {account.Sum}: {reason}.");
        }
    }
}
