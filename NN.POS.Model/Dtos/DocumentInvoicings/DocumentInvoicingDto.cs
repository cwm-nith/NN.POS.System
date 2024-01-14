using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.DocumentInvoicings;

public class DocumentInvoicingDto : IBaseDto
{
    public int Id { get; set; }
    public int DocId { get; set; }
    public string DocInvoicing { get; set; } = string.Empty;
    public int InvoiceCount { get; set; }
    public string PreFix { get; set; } = string.Empty;
    public DocumentInvoicingType Type { get; set; }
    public DateTime CreatedAt { get; set; }
}