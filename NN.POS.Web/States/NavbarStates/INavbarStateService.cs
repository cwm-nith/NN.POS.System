using MudBlazor;

namespace NN.POS.Web.States.NavbarStates;

public interface INavbarStateService : IStateBaseService
{
    string Value { get; }
    string ActiveValue { get; }
    List<BreadcrumbItem> BreadcrumbItems { get; }
    void SetExpend(string value);
    void SetActive(string value, bool isNotify = false);
    void SetBreadcrumbItems(List<BreadcrumbItem> breadcrumbItems, bool isNotify = false);
};