using System.Linq.Expressions;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Core.Exceptions.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables;
using NN.POS.System.API.Infra.Tables.BusinessPartners;

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

    public Task<bool> DeleteAsync(int id, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public async Task<BusinessPartnerEntity> GetByIdAsync(int id, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation) ?? throw new BusinessPartnerNotFoundException(id);
        return data.ToEntity();
    }

    public Task<int> GetCountAsync(CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<BusinessPartnerEntity>> GetAllAsync(Expression<Func<BusinessPartnerTable, bool>> predicate, PagedQuery q, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}