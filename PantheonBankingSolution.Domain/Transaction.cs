using System;

namespace PantheonBankingSolution.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public virtual Account Account { get; set; }
    }
}