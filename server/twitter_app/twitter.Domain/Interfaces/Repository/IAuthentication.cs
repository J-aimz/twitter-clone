using AspNetCoreHero.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Dtos;
using twitter.Domain.Models;

namespace twitter.Domain.Interfaces.Repository
{
    public interface IAuthentication
    {
        Task<AppUser> Registration(RegistrationDto registrationDto);
    }
}
