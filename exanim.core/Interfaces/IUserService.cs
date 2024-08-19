using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IUserService : IService<UserDTO>
{
    Task<IEnumerable<UserDTO>> AllAsync();
}
