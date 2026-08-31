using System.Security.Claims;

namespace exanim.core.DTOs;

public record AuthMe(Guid IdUsu, Guid? IdAgen);