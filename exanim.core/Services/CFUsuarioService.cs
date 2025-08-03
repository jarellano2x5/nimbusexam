using AutoMapper;
using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;

namespace exanim.core.Services;

public class CFUsuarioService : ICFUsuarioService
{
    private readonly IRepository<CFUsuario> _repo;
    private readonly IMapper _mapper;

    public CFUsuarioService(IRepository<CFUsuario> repository, IMapper mapper)
    {
        _repo = repository;
        _mapper = mapper;
    }
    
    public async Task<CFUsuarioDTO> AddAsync(CFUsuarioDTO dto)
    {
        try
        {
            CFUsuario model = _mapper.Map<CFUsuario>(dto);
            model.UsuarioId = Guid.NewGuid();
            await _repo.InsertAsync(model);
            dto.UsuarioId = model.UsuarioId;
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<CFUsuarioDTO>> AllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<CFUsuarioDTO>>(
                await _repo.SearchAsync(o => 1 == 1)
            );
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<CFUsuarioDTO> AttachAsync(Guid id, CFUsuarioDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CFUsuarioDTO> PickAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
