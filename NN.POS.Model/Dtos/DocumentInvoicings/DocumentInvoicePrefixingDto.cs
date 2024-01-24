using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.DocumentInvoicings;

public class DocumentInvoicePrefixingDto : IBaseDto
{
    public int Id { get; set; }
    public string Prefix { get; set; } = string.Empty;
    public DocumentInvoicingType Type { get; set; }
    public DateTime CreatedAt { get; set; }
}