using Microsoft.AspNetCore.Components;

namespace NN.POS.Web.Extensions;

public static class NavigationManagerExtension
{
    public static string? GetSection(this NavigationManager navMan, int index = 0)
    {
        // get the absolute path without the base path
        var currentUri = navMan.Uri.Remove(0, navMan.BaseUri.Length - 1);
        var firstElement = currentUri
            .Split("/", StringSplitOptions.RemoveEmptyEntries)[index];
        Console.WriteLine(firstElement);
        return firstElement;
    }
}