using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Tax;
using NN.POS.API.Core.Exceptions.Tax;
using NN.POS.API.Core.IRepositories.Tax;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Tax;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Infra.Repositories.Tax;

public class TaxRepository(IReadDbRepository<TaxTable> readDbRepository,
    IWriteDbRepository<TaxTable> writeDbRepository) : ITaxRepository
{
    public async Task CreateAsync(TaxDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(TaxDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var tax = await GetByIdAsync(id, cancellationToken);
        tax.IsDeleted = true;
        await writeDbRepository.UpdateAsync(tax.ToTable(), cancellationToken);
    }

    public async Task<TaxDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var tax = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id, cancellationToken) ??
                  throw new TaxNotFoundException(id);
        return tax.ToDto();
    }

    public async Task<PagedResult<TaxDto>> GetPageAsync(GetTaxPageQuery query, CancellationToken cancellationToken = default)
    {
        PagedResult<TaxTable> data;
        if (string.IsNullOrWhiteSpace(query.Search))
        {
            data = await readDbRepository.BrowseAsync(i => !i.IsDeleted, i => i.CreatedAt, query, cancellationToken);
        }
        else
        {
            data = await readDbRepository.BrowseAsync(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{query.Search}%"), i => i.CreatedAt, query, cancellationToken);
        }

        return data.Map(i => i.ToDto());
    }
}