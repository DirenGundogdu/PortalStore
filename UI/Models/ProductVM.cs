using DTO;

namespace UI.Models
{
    public class ProductVM
    {
        public List<ProductDto> ProductList { get; set; }
        public ProductDto Product { get; set; }

        public List<CategoryDto> CategoryDtos { get; set; }
    }
}
