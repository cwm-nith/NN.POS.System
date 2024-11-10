using MudBlazor;

namespace NN.POS.Web.States.ThemeState;

public interface IThemeStateService : IStateBaseService
{
    bool IsDark { get; set; }
    MudTheme Theme { get; set; }
    Task ToggleThemeMode();
    Task LoadIsDarkAsync();
};