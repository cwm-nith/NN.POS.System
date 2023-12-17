namespace NN.POS.Web.States.NavbarStates;

public interface INavbarStateService : IStateBaseService
{
    string Value { get; }
    void SetExpendAsync(string value);
};