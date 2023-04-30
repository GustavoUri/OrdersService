namespace OrdersService.Domain.Entities;

public enum OrderStatus
{
    New,
    AwaitingPayment,
    Paid,
    SentForDelivery,
    Delivered,
    Completed
}