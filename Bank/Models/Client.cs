using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Client : Person
    {   
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
