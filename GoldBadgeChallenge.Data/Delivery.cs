using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Delivery
{
    public Delivery()
    {
        Status = OrderStatus.Scheduled;
    }

    public Delivery(int itemNumber, int itemQuantity, int customerId)
    {
        ItemNumber = itemNumber;
        ItemQuantity = itemQuantity;
        CustomerId = customerId;
        Status = OrderStatus.Scheduled;
    }

    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public DateTime DeliveryDate => OrderDate.AddDays(14);
    public OrderStatus Status { get; set; }
    public int ItemNumber { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerId { get; set; }
}