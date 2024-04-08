using Azure.Core;
using MediatR;
using MediatR.Pipeline;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderInputPort OutputPort;
        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork,
            ICreateOrderInputPort outputPort) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork, OutputPort) =
            (orderRepository, orderDetailRepository, unitOfWork, outputPort);

        public async Task Handle(CreateOrdeParams order)
        {
            Order Order = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(Order);
            foreach (var Item in order.OrderDetails)
            {
                OrderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = Order,
                        ProductId = Item.ProductId,
                        UnitPrice = Item.UnitPrice,
                        Quantity = Item.Quantity,
                    });
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.",
                    ex.Message);
            }
            await OutputPort.Handle(Order.Id);
        }        
    }
}
