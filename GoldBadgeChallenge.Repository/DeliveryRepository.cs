using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeliveryRepository
{
    private List<Delivery> _deliveries;

    public DeliveryRepository()
    {
        _deliveries = new List<Delivery>();
    }

    public void CreateDelivery(Delivery delivery)
    {
        _deliveries.Add(delivery);
    }

    public List<Delivery> GetAllDeliveries()
    {
        return _deliveries;
    }

    public List<Delivery> GetEnRouteDeliveries()
    {
        return _deliveries.FindAll(delivery => delivery.Status == OrderStatus.EnRoute);
    }

    public List<Delivery> GetCompletedDeliveries()
    {
        return _deliveries.FindAll(delivery => delivery.Status == OrderStatus.Complete);
    }

    public void UpdateDeliveryStatus(Delivery delivery, OrderStatus newStatus)
    {
        delivery.Status = newStatus;
    }

    public void CancelDelivery(Delivery delivery)
    {
        delivery.Status = OrderStatus.Canceled;
    }
    
    public Delivery GetDeliveryById(int deliveryId)
    {
        return _deliveries.FirstOrDefault(d => d.Id == deliveryId)!;
    }

    public void UpdateDeliveryStatus(Delivery delivery)
    {
        Delivery existingDelivery = _deliveries.FirstOrDefault(d => d.Id == delivery.Id)!;
        if (existingDelivery != null)
        {
            existingDelivery.Status = delivery.Status;
        }
        else
        {
            throw new ArgumentException("Delivery not found.");
        }
    }

    public List<Delivery> GetDeliveriesByStatus(OrderStatus status)
    {
        return _deliveries.Where(d => d.Status == status).ToList();
    }
}