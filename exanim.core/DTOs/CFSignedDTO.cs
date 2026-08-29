using exanim.core.Enums;

namespace exanim.core.DTOs;

public record CFSignedDTO
(
    string Usuario,
    bool EsTitular,
    Guid? AgenciaId,
    string Token
);
