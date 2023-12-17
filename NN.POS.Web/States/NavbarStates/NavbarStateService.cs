namespace NN.POS.Web.States.NavbarStates;

public class NavbarStateService : INavbarStateService
{
    public event Action? OnStateChange;
    
    public string Value { get; private set; } = string.Empty;

    public void SetExpendAsync(string value)
    {
        Value = value;
        NotifyStateChanged();
    }

    /// <summary>
    /// The state change event notification
    /// </summary>
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}