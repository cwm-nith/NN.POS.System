using MudBlazor;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.BusinessPartners;
using NN.POS.System.Web.Constants;
using System.Net.Http.Json;

namespace NN.POS.System.Web.Pages.Suppliers;


public partial class Index
{
    private MudTable<BusinessPartnerDto>? Table { get; set; }
    private async Task<TableData<BusinessPartnerDto>> ServerReload(TableState state)
    {
        var httpClient = HttpClientFactory.CreateClient(AppConstants.HttpClientName);
        var data =
            await httpClient.GetFromJsonAsync<PagedResult<BusinessPartnerDto>>($"{Setting.PrefixEndpoint}BusinessPartner");
        return new TableData<BusinessPartnerDto>
        {
            Items = data?.Items ?? new List<BusinessPartnerDto>(),
            TotalItems = Convert.ToInt32(data?.TotalResults)
        };
    }
    //private void OnSearch(string text)
    //{
    //    _searchString = text;
    //    Table?.ReloadServerData();
    //}
}