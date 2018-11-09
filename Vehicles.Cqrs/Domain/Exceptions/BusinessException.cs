using System;

namespace Vehicles.Cqrs.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
        {}
    }
}