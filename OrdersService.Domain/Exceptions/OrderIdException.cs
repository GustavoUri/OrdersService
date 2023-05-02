using System.Runtime.Serialization;

namespace OrdersService.Domain.Exceptions;

public class OrderIdException :Exception
{
    public OrderIdException()
    {
    }

    public OrderIdException(string message)
        : base(message)
    {
    }

    public OrderIdException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected OrderIdException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}