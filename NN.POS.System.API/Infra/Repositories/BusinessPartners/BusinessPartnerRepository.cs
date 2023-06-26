using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Core.Exceptions.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables;
using NN.POS.System.API.Infra.Tables.BusinessPartners;
using NN.POS.System.Common.Pagination;

namespace NN.POS.System.API.Infra.Repositories.BusinessPartners;

public class BusinessPartnerRepository : IBusinessPartnerRepository
{
    private readonly IWriteDbRepository<BusinessPartnerTable> _writeDbRepository;
    private readonly IReadDbRepository<BusinessPartnerTable> _readDbRepository;

    public BusinessPartnerRepository(IReadDbRepository<BusinessPartnerTable> readDbRepository,
        IWriteDbRepository<BusinessPartnerTable> writeDbRepository)
    {
        _readDbRepository = readDbRepository;
        _writeDbRepository = writeDbRepository;
    }

    public async Task<BusinessPartnerEntity> CreateAsync(BusinessPartnerEntity entity, CancellationToken cancellation = default)
    {
        var bus = await _writeDbRepository.AddAsync(entity.ToTable(), cancellation);
        return bus.ToEntity();
    }

    public Task UpdateAsync(BusinessPartnerEntity entity, CancellationToken cancellation = default)
    {
        return _writeDbRepository.UpdateAsync(entity.ToTable(), cancellation);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellation = default)
    {
        var num = await _writeDbRepository.DeleteAsync(id, cancellation);
        return num > 0;
    }

    public async Task<BusinessPartnerEntity> GetByIdAsync(int id, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation) ?? throw new BusinessPartnerNotFoundException(id);
        return data.ToEntity();
    }

    public Task<int> GetCountAsync(CancellationToken cancellation = default)
    {
        return _readDbRepository.Context.BusinessPartners!.CountAsync(cancellation);
    }

    public async Task<PagedResult<BusinessPartnerEntity>> GetAllAsync(Expression<Func<BusinessPartnerTable, bool>> predicate, PagedQuery q, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.BrowseAsync(predicate, q, cancellation);
        return data.Map(i => i.ToEntity());
    }
}