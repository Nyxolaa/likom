namespace erp_likom_model.Models
{
    public class FinancialTransaction
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public Order? Order { get; set; }
    }
}
