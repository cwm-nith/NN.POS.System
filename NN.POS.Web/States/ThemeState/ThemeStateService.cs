using Blazored.LocalStorage;
using MudBlazor;

namespace NN.POS.Web.States.ThemeState;

public class ThemeStateService(ILocalStorageService localStorageService) : IThemeStateService
{
    public event Action? OnStateChange;

    public bool IsDark { get; set; }
    public MudTheme Theme { get; set; } = new();

    public async Task ToggleThemeMode()
    {
        IsDark = !IsDark;
        await localStorageService.SetItemAsync<bool>("dark_mode", IsDark);
        NotifyStateChanged();
    }

    public async Task LoadIsDarkAsync()
    {
        IsDark = await localStorageService.GetItemAsync<bool>("dark_mode");
    }

    /// <summary>
    /// The state change event notification
    /// </summary>
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}