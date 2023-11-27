using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Application.Home.Query
{
    public class HomeTestQuery : IRequest<IResult<string>>
    {
    }
}
