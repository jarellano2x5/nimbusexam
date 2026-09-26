namespace exanim.core.DTOs;

public record DPage<T> where T : class
{
    public int Count { get; set; }
    public int Pages { get; set; }
    public int Limit { get; set; }
    public IEnumerable<T> Records { get; set; } = [];
}
