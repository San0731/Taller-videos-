using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCases.Common.Ports;


namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrdeParams, int>
    {
        public CreateOrdeParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }
        public CreateOrderInputPort(CreateOrdeParams requestData,
            IOutputPort<int> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);
    }
}
