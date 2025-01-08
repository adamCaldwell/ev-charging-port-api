using AutoMapper;
using EVChargingPort.API.Domain.Models;
using EVChargingPort.API.Infrastructure.DbContexts;
using EVChargingPort.API.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.Infrastructure.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public ApplicationRepository(ApplicationContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public async Task AddApplicationAsync(UserApplication application)
    {
        var applicationEntity = _mapper.Map<Application>(application);
        await _context.Applications.AddAsync(applicationEntity);

        await _context.SaveChangesAsync();

        return;
    }
}