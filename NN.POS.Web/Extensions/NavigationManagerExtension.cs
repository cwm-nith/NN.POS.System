using Microsoft.AspNetCore.Components;

namespace NN.POS.Web.Extensions;

public static class NavigationManagerExtension
{
    public static string? GetSection(this NavigationManager navMan)
    {
        // get the absolute path with out the base path
        var currentUri = navMan.Uri.Remove(0, navMan.BaseUri.Length - 1);
        var firstElement = currentUri
            .Split("/", StringSplitOptions.RemoveEmptyEntries)
            .FirstOrDefault();
        return firstElement;
    }
}