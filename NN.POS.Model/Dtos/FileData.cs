namespace NN.POS.Model.Dtos;

public class FileData
{
    public byte[] ImageBytes { get; set; } = [];
    public string FileName { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public long FileSize { get; set; }
}