using System;
using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;

namespace exanim.core.Services;

public class AgencyService : IAgencyService
{
    private readonly IRepository<Agency> _repo;

    public AgencyService(IRepository<Agency> repository)
    {
        _repo = repository;
    }
    
    public Task<AgencyDTO> AddAsync(AgencyDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<AgencyDTO> AttachAsync(Guid id, AgencyDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Item>> ItemsAsync(string srch)
    {
        throw new NotImplementedException();
    }

    public Task<AgencyDTO> PickAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
