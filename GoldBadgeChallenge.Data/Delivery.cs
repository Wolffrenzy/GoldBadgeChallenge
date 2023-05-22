using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Delivery
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Status { get; set; }
    public int ItemNumber { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerId { get; set; }
}