namespace Data.DTOs;

public abstract class BaseDto
{
    public int Id { get; set; }

    public bool Status { get; set; } = true;

    public DateTime CreateDate { get; set; } = DateTime.Now;
}
