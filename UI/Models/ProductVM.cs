using DTO;

namespace UI.Models
{
    public class ProductVM
    {
        public List<ProductDto> ProductList { get; set; }
        public ProductProcessDto Product { get; set; }

        public List<CategoryDto> CategoryDtos { get; set; }
    }
}
