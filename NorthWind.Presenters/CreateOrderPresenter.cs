
using Azure;
using NorthWind.UseCasesPorts.CreateOrder;
using System;
using System.Threading.Tasks;

namespace NorthWind.Presenters
{
    public class CreateOrderPresenter : IcreateOrderOutputPort, IPresenter<string>
    {
        

        public string Content { get; private set; }

        public Task Handle(int orderId)
        {
            Content = $"Order ID: {orderId}";
            return Task.CompletedTask;
        }
    }    
}