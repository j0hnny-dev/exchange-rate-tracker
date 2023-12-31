﻿using AutoMapper;
using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace ExchangeRate.Tracker.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ExchangeRateDbContext _dbContext;

    public IRepository<ExchangeRateEntity> ExchangeRateRepository { get; private init; }

    public UnitOfWork(ExchangeRateDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        ExchangeRateRepository = new ExchangeRateRepository(dbContext, mapper);
    }

    public async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
    }
}
