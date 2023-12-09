using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Dtos;
using twitter.Domain.Models;

namespace twitter.Application.Authentication.Command.Registration
{
    public class RegistrationCommand : IRequest<IResult<RegistrationResponse>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

       
    }


	public class RegistrationResponse  : RegistrationCommand
	{
		
	}
}
