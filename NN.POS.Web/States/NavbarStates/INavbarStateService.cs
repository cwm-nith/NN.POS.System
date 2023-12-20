namespace NN.POS.Web.States.NavbarStates;

public interface INavbarStateService : IStateBaseService
{
    string Value { get; }
    string ActiveValue { get; }
    void SetExpend(string value);
    void SetActive(string value, bool isNotify = false);
};