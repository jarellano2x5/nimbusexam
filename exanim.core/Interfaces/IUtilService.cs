using System;
using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IUtilService
{
    IEnumerable<Option> GetPerfil();
}
