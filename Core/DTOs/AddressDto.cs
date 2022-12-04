using Core.Entities;
using Data.DTOs;

namespace Core.DTOs;

public class AddressDto : BaseDto
{
    public string? AddressLine { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public int ZipCode { get; set; }

    public int CustomerId { get; set; }

    public CustomerDto CustomerDto { get; set; }
}
