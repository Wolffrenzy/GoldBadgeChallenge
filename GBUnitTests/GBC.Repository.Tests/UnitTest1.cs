using System;
using System.Collections.Generic;
using Xunit;

namespace DeliveryService.Tests
{
    public class DeliveryRepositoryTests
    {
        [Fact]
        public void CreateDelivery_ShouldAddDeliveryToRepository()
        {
            // Arrange
            var deliveryRepository = new DeliveryRepository();
            var delivery = new Delivery
            {
                OrderDate = DateTime.Parse("2023-05-20"),
                Status = OrderStatus.Scheduled, 
                ItemNumber = 1,
                ItemQuantity = 2,
                CustomerId = 12345
            };

            // Act
            deliveryRepository.CreateDelivery(delivery);
            var deliveries = deliveryRepository.GetAllDeliveries();

            // Assert
            Assert.Contains(delivery, deliveries);
        }
    }
}