using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.UseCasesDTOs.CreateOrder;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : CreateOrdeParams, IRequest<int>
    {

    }
}
