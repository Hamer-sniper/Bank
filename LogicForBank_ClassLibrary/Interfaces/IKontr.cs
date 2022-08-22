using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForBank_ClassLibrary.Models;

namespace LogicForBank_ClassLibrary.Interfaces
{
    public interface IKontr<in T>
        where T : Counterparty
    {
        void SetValueMethod(T args);

        void Transact(string from, string to, string sum);
    }
}
