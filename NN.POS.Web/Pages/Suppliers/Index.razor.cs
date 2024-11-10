using System.Net.Http.Json;
using MudBlazor;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners;
using NN.POS.Web.Constants;
using NN.POS.Web.Pages.Suppliers.Dialogs;

namespace NN.POS.Web.Pages.Suppliers;

public partial class Index : IDisposable
{

    private MudTable<BusinessPartnerDto>? _table;
    private string _searchString = "";

    protected override void OnInitialized()
    {
        NavbarStateService.SetExpend(RouteName.Contact);
        NavbarStateService.SetActive(RouteName.Supplier);
        NavbarStateService.OnStateChange += StateHasChanged;
    }

    public void Dispose()
    {
        NavbarStateService.OnStateChange -= StateHasChanged;
    }

    private async Task<TableData<BusinessPartnerDto>> ServerReload(TableState state, CancellationToken cancellationToken)
    {
        var httpClient = HttpClientFactory.CreateClient(AppConstants.HttpClientName);
        var uri = $"{Setting.PrefixEndpoint}BusinessPartner?ContactType=1&Page={state.Page + 1}&Results={state.PageSize}";
        var data = await httpClient.GetFromJsonAsync<PagedResult<BusinessPartnerDto>>(uri, cancellationToken);
        return new TableData<BusinessPartnerDto>
        {
            Items = data?.Items,
            TotalItems = Convert.ToInt32(data?.TotalResults)
        };
    }

    private void GoToUpdatePage(int id)
    {
        NavigationManager.NavigateTo($"{RouteName.UpdateSupplier}/{id}");
    }

    private void DeleteSupplier(int id)
    {
        var parameters = new DialogParameters<DeleteDialog>
        {
            {
                x => x.Id, id
            },
            {
                x => x.Table, _table
            }
        };

        var options = new DialogOptions() { CloseButton = true};

        Dialog.Show<DeleteDialog>("Delete", parameters, options);
    }

    private void OnSearch(string text)
    {
        _searchString = text;
        _table?.ReloadServerData();
    }
}