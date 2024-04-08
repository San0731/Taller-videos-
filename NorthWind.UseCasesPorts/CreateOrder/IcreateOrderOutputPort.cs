using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCasesPorts.CreateOrder
{
    public interface IcreateOrderOutputPort
    {
        Task Handle(int orderId);
    }
}
