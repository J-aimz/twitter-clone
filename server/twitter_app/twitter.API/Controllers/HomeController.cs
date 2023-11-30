using Microsoft.AspNetCore.Mvc;
using twitter.Application.Home.Query;

namespace twitter.API.Controllers
{

	public class HomeController : ApiController
    {
       
        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<ApiController> logger) : base(logger)
		{
		}

		[HttpGet("/get-home")]
        public async Task<IActionResult> HomeTestQueryAsync()
        {   
            return await Initiate(() => Mediator.Send(new HomeTestQuery()));
        }
    }
}
