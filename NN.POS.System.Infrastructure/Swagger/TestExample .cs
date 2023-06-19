using Swashbuckle.AspNetCore.Filters;

namespace NN.POS.System.Infrastructure.Swagger;

public abstract class TestExample : IExamplesProvider<object>
{
    public object GetExamples()
    {
        return "";
    }
}