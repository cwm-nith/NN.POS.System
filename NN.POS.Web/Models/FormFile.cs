namespace NN.POS.Web.Models;

public class FormFile
{

    public FormFile(string name, Stream content, long contentSize)
    {
        Name = name;
        ContentSize = contentSize;
        _ = Task.Run(async () =>
        {
            await content.CopyToAsync(Content);
            Content.SetLength(contentSize);
        });
    }
    public string Name { get; set; }
    public Stream Content { get; } = new MemoryStream();
    public long ContentSize { get; set; }



}