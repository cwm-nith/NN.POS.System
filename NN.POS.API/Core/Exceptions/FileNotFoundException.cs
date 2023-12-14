namespace NN.POS.API.Core.Exceptions;

public class FileNotFoundException(string? path) : BaseException($"File \"{path}\" could not be found.")
{
    public override string Code => "file_nf";
}