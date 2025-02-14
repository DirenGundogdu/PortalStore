﻿namespace DTO;

public class AddressProcessDto
{
    public int Id { get; set; }
    public string? AddressLine { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public int ZipCode { get; set; }

    public int CustomerId { get; set; }
}
