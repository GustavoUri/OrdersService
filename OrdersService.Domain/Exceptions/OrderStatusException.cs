using System.Runtime.Serialization;

namespace OrdersService.Domain.Exceptions;

public class OrderStatusException : Exception
{
    public OrderStatusException()
    {
    }

    public OrderStatusException(string message)
        : base(message)
    {
    }

    public OrderStatusException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected OrderStatusException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}