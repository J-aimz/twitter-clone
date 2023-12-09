using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Application.Home.Query
{
    public class HomeTestQuer2yHandler : IRequestHandler<HomeTestQuery, IResult<string>>
    {
        public async Task<IResult<string>> Handle(HomeTestQuery request, CancellationToken cancellationToken)
        {
              return await Result<string>.SuccessAsync("Hello world");
        }
    }
}

