using Microsoft.Graph;
using Microsoft.Graph.Models;
using NorthWind.UseCases.Common.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Presenters
{
    public interface IPresenter<REesponseType, FormatType>: IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}
