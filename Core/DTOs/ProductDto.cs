using Core.Entities;
using Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class ProductDto : BaseDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal OldPrice { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public CategoryDto CategoryDto { get; set; }
}
