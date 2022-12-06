using DTO;

namespace UI.Models
{
    public class BasketVM
    {
        public List<BasketDto> basketDtos { get; set; }

        public List<AddressDto> addressDtos { get; set; }
    }
}
