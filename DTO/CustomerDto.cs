namespace DTO;

public class CustomerDto : BaseDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public long TCID { get; set; }

    public DateTime Birthdate { get; set; }

    public string? Gsm { get; set; }
}
