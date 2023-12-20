namespace NN.POS.Web.States.NavbarStates;

public class NavbarStateService : INavbarStateService
{
    public event Action? OnStateChange;
    
    public string Value { get; private set; } = string.Empty;
    public string ActiveValue { get; set; } = string.Empty;

    public void SetExpend(string value)
    {
        Value = value;
        NotifyStateChanged();
    }

    public void SetActive(string value, bool isNotify = false)
    {
        ActiveValue = value;
        if (isNotify)
        {
            NotifyStateChanged();
        }
    }

    /// <summary>
    /// The state change event notification
    /// </summary>
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}