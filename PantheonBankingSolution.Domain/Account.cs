using System;
using System.Collections.Generic;

namespace PantheonBankingSolution.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public virtual Customer Customer { get; set; }
    }
}