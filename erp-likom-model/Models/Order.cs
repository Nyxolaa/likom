﻿namespace erp_likom_model.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<FinancialTransaction>? FinancialTransactions { get; set; }

    }
}
