﻿using MudBlazor;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.BusinessPartners;
using NN.POS.System.Web.Constants;
using System.Net.Http.Json;

namespace NN.POS.System.Web.Pages.Suppliers;


public partial class Index
{
    private async Task<TableData<BusinessPartnerDto>> ServerReload(TableState state)
    {
        var httpClient = HttpClientFactory.CreateClient(AppConstants.HttpClientName);
        var data =
            await httpClient.GetFromJsonAsync<PagedResult<BusinessPartnerDto>>($"{Setting.PrefixEndpoint}BusinessPartner?ContactType=1&Page={state.Page}&Results={state.PageSize}");

        return new TableData<BusinessPartnerDto>
        {
            Items = data?.Items,
            TotalItems = Convert.ToInt32(data?.TotalResults)
        };
    }

    protected void GoToUpdatePage(int id)
    {
        NavigationManager.NavigateTo($"{RouteName.UpdateSupplier}/{id}");
    }
}