﻿namespace DTO;

public class ProductProcessDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal OldPrice { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}
