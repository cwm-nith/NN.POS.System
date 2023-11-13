using Swashbuckle.AspNetCore.Filters;

namespace NN.POS.System.API.Infra.Swagger;

public abstract class TestExample : IExamplesProvider<object>
{
    public object GetExamples()
    {
        throw new NotImplementedException();
    }
}