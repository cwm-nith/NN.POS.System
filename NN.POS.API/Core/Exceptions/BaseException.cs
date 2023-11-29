namespace NN.POS.API.Core.Exceptions;

public abstract class BaseException : Exception
{
    public abstract string Code { get; }
    public int StatusCode { get; } = 400;
    public object AdditionalData { get; set; } = new ();
    protected BaseException(string message) : base(message)
    {
    }
    protected BaseException(string message, int statusCode, object additionalData) : this(message, additionalData)
    {
        StatusCode = statusCode;
    }

    protected BaseException(string message, int statusCode) : this(message, statusCode, new object())
    {
    }

    protected BaseException(string message, object additionalData) : this(message)
    {
        AdditionalData = additionalData;
    }

    protected BaseException()
    {
    }

    protected BaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}