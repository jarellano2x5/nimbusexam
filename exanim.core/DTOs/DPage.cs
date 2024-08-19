using System;

namespace exanim.core.DTOs;

public class DPage<T> where T : class
{
    public int Count { get; set; }
    public int Pages { get; set; }
    public int Limit { get; set; }
    public IEnumerable<T> Records { get; set; } = [];
}
