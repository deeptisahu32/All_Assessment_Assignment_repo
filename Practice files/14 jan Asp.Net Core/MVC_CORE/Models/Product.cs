using System.Globalization;

namespace MVC_CORE.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal price {  get; set; }
        public string Category {  get; set; } = string.Empty;
        public decimal StockQty {  get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public DateTime CreatedDate {  get; set; }
        public bool IsActive {  get; set; }
        
    }
}
