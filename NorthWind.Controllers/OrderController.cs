using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;
using System;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly IcreateOrderOutputPort OutputPort;
        //readonly IPresenter<string> Presenter;
        public OrderController(ICreateOrderInputPort inputPort,
            IcreateOrderOutputPort outputPort) =>
            (InputPort, outputPort) = (inputPort, outputPort);

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(
            CreateOrderParams orderparams)
        {
            await InputPort.Handle(orderparams);
            var Presenter = OutputPort as CreateOrderPresenter;
            return Presenter.Content;
        }
    }
}