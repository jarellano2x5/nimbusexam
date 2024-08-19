using AutoMapper;
using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;

namespace exanim.core.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _repo;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> repository, IMapper mapper)
    {
        _repo = repository;
        _mapper = mapper;
    }
    
    public async Task<UserDTO> AddAsync(UserDTO dto)
    {
        try
        {
            User model = _mapper.Map<User>(dto);
            model.UserId = Guid.NewGuid();
            await _repo.InsertAsync(model);
            dto.UserId = model.UserId;
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<UserDTO> AttachAsync(Guid id, UserDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> PickAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
