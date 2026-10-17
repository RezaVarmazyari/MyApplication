namespace MyApplication.Models
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
//navigation property
        public Category Category { get; set; }
        public Product Product { get; set; }

    }

}