using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Tables;

[Table("document_invoicing")]
public class DocumentInvoicingTable : BaseTable
{
    [Column("doc_id")]
    public int DocId { get; set; }

    [Column("doc_invoicing"), StringLength(50)]
    public string DocInvoicing { get; set; } = string.Empty;

    [Column("invoice_count")]
    public int InvoiceCount { get; set; }

    [Column("prefix"), StringLength(10)]
    public string PreFix { get; set; } = string.Empty;

    [Column("type"), StringLength(50)]
    public DocumentInvoicingType Type { get; set; }
}

public static class DocumentInvoicingExtensions
{
    public static DocumentInvoicingDto ToDto(this DocumentInvoicingTable di) => new()
    {
        CreatedAt = di.CreatedAt,
        DocId = di.DocId,
        DocInvoicing = di.DocInvoicing,
        Id = di.Id,
        Type = di.Type,
        InvoiceCount = di.InvoiceCount,
        PreFix = di.PreFix
    };

    public static DocumentInvoicingTable ToTable(this DocumentInvoicingDto di) => new()
    {
        CreatedAt = di.CreatedAt,
        DocId = di.DocId,
        DocInvoicing = di.DocInvoicing,
        Id = di.Id,
        Type = di.Type,
        InvoiceCount = di.InvoiceCount,
        PreFix = di.PreFix
    };
}