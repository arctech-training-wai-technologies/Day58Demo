﻿namespace Day58Demo.Models.Services.Exceptions;

public class IdNotFoundException : Exception
{
    public IdNotFoundException(string message) : base(message)
    {
    }
}