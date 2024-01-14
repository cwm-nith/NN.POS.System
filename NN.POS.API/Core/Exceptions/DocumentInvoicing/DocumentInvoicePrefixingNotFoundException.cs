namespace NN.POS.API.Core.Exceptions.DocumentInvoicing;

public class DocumentInvoicePrefixingNotFoundException() : BaseException("Document Invoice Prefixing could not be found")
{
    public override string Code => "doc_inv_pre_nf";
}