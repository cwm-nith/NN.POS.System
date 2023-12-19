using System.Text;

namespace NN.POS.Common.Helpers;

public static class ConvertorHelper
{
    public static Stream ConvertToBase64(this Stream stream)
    {
        byte[] bytes;
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            bytes = memoryStream.ToArray();
        }

        var base64 = Convert.ToBase64String(bytes);
        return new MemoryStream(Encoding.UTF8.GetBytes(base64));
    }
}