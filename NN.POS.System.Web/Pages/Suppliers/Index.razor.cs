using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.BusinessPartners;
using NN.POS.System.Web.Constants;
using System.Net.Http.Json;

namespace NN.POS.System.Web.Pages.Suppliers;


public partial class Index
{
    private IEnumerable<BusinessPartnerDto> _suppliers = new List<BusinessPartnerDto>();
    private string _searchString = "";
    protected override async Task OnInitializedAsync()
    {
        var httpClient = HttpClientFactory.CreateClient(AppConstants.HttpClientName);
        var data = await httpClient.GetFromJsonAsync<PagedResult<BusinessPartnerDto>>($"{Setting.PrefixEndpoint}BusinessPartner?ContactType=1&Page=-1&Results=1");
        _suppliers = data?.Items ?? new List<BusinessPartnerDto>();
    }

    protected void GoToUpdatePage(int id)
    {
        NavigationManager.NavigateTo($"{RouteName.UpdateSupplier}/{id}");
    }

    private bool FilterFunc1(BusinessPartnerDto element) => FilterFunc(element, _searchString);

    private static bool FilterFunc(BusinessPartnerDto element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.Email?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false)
            return true;
        return element.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase);
    }

}