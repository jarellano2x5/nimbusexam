using System;
using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public class AgencyDTO
{
    public Guid AgencyId { get; set; }
    [Length(5, 30)]
    public string Alias { get; set; } = string.Empty;
    [Length(5, 200)]
    public string Name { get; set; } = string.Empty;
    [Length(5, 400)]
    public string Address { get; set; } = string.Empty;
    [Length(5, 5)]
    public string ZipCode { get; set; } = string.Empty;
    public LocationDTO Place { get; set; } = null!;
    public bool IsActive { get; set; }
}
