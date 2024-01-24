using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Tables.DocumentInvoicing;

[Table("document_invoice_prefixing")]
public class DocumentInvoicePrefixingTable : BaseTable
{
    [Column("prefix"), StringLength(10)]
    public string Prefix { get; set; } = string.Empty;

    [Column("type")]
    public DocumentInvoicingType Type { get; set; }
}

public static class DocumentInvoicePrefixingExtensions
{
    public static DocumentInvoicePrefixingDto ToDto(this DocumentInvoicePrefixingTable d) => new()
    {
        CreatedAt = d.CreatedAt,
        Id = d.Id,
        Type = d.Type,
        Prefix = d.Prefix
    };
    public static DocumentInvoicePrefixingTable ToTable(this DocumentInvoicePrefixingDto d) => new()
    {
        CreatedAt = d.CreatedAt,
        Id = d.Id,
        Type = d.Type,
        Prefix = d.Prefix
    };
}