namespace ProductEngine.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal MRP { get; set; } 
        public decimal ProfitPerUnit { get; set; }
        public decimal ProfitPercentage { get; set; }

    }
}
