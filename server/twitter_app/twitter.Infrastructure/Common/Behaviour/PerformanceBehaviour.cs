using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Interfaces.Common;

namespace twitter.Infrastructure.Common.Behaviour
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ICurrentUserService _currentUserService;
        private ILogger<PerformanceBehaviour<TRequest, TResponse>> _logger;

        public PerformanceBehaviour(ICurrentUserService currentUserService, ILogger<PerformanceBehaviour<TRequest, TResponse>> logger)
        {
            _timer = new Stopwatch();
            _currentUserService = currentUserService;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {


            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService;
                //var userId = _currentUserService.UserId;

                _logger.LogWarning(
                    $"Long Running Request: {requestName} ({elapsedMilliseconds} milliseconds) by {userId}. Details: {request}");
            }

            return response;
        }
    }
}
