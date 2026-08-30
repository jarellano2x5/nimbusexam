namespace exanim.core.DTOs;

public record Item
(Guid Id, string Name, string Code = "", bool Activo = true);
