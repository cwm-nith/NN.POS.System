﻿namespace NN.POS.API.Core.Exceptions.Users;

public class InvalidPasswordException : BaseException
{
    public InvalidPasswordException(string message) : base(message)
    {
    }

    public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidPasswordException()
    {
    }

    public override string Code => "invalid_password";
}