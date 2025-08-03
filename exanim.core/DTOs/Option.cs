namespace exanim.core.DTOs;

public record Option
{
    public byte Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
