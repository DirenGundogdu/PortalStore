﻿namespace Core.Entities;

public class Category : Base
{
    public string? Name { get; set; }

    public List<Product>? Products { get; set; }
}
