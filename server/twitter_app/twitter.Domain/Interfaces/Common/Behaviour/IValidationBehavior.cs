using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Interfaces.Common.Behaviour
{
    public interface IValidationBehavior<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken);
    }
}
