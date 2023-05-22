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

    public List<Delivery> ListEnRouteDeliveries()
    {
        return _deliveries.FindAll(delivery => delivery.Status == "EnRoute");
    }

    public List<Delivery> ListCompletedDeliveries()
    {
        return _deliveries.FindAll(delivery => delivery.Status == "Complete");
    }

    public void UpdateDeliveryStatus(Delivery delivery, string newStatus)
    {
        delivery.Status = newStatus;
    }

    public void CancelDelivery(Delivery delivery)
    {
        delivery.Status = "Canceled";
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            DeliveryRepository repo = new DeliveryRepository();

            // Add a new delivery to the history (Create)
            Delivery newDelivery = new Delivery
            {
                OrderDate = DateTime.Parse("2023-05-20"),
                DeliveryDate = DateTime.Parse("2023-05-21"),
                Status = "Scheduled",
                ItemNumber = 1,
                ItemQuantity = 2,
                CustomerId = 1
            };
            repo.CreateDelivery(newDelivery);

            // List all en route deliveries and completed deliveries (Read)
            List<Delivery> enRouteDeliveries = repo.ListEnRouteDeliveries();
            List<Delivery> completedDeliveries = repo.ListCompletedDeliveries();
            Console.WriteLine("En Route Deliveries:");
            foreach (Delivery delivery in enRouteDeliveries)
            {
                Console.WriteLine($"{delivery.OrderDate} {delivery.DeliveryDate} {delivery.Status} {delivery.ItemNumber} {delivery.ItemQuantity} {delivery.CustomerId}");
            }

            Console.WriteLine("\nCompleted Deliveries:");
            foreach (Delivery delivery in completedDeliveries)
            {
                Console.WriteLine($"{delivery.OrderDate} {delivery.DeliveryDate} {delivery.Status} {delivery.ItemNumber} {delivery.ItemQuantity} {delivery.CustomerId}");
            }

            // Update the status of a delivery (Update)
            Delivery deliveryToUpdate = enRouteDeliveries[0];
            repo.UpdateDeliveryStatus(deliveryToUpdate, "Complete");

            // Cancel a delivery (Delete)
            Delivery deliveryToCancel = enRouteDeliveries[1];
            repo.CancelDelivery(deliveryToCancel);
        }
    }
    public Delivery GetDeliveryById(int deliveryId)
    {
        return _deliveries.FirstOrDefault(d => d.Id == deliveryId)!;
    }
    public void UpdateDeliveryStatus(int deliveryId, string newStatus)
    {
        Delivery delivery = _deliveries.FirstOrDefault(d => d.Id == deliveryId)!;
        if (delivery != null)
        {
            delivery.Status = newStatus;
        }
    }

    public List<Delivery> GetDeliveriesByStatus(string status)
    {
        return _deliveries.Where(d => d.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
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
            // Handle the case when the delivery is not found
            throw new ArgumentException("Delivery not found.");
        }
    }
}