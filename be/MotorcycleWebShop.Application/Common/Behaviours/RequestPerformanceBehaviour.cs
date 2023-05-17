using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleWebShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebShop.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMiliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMiliseconds > 500)
            {
                //var requestName = typeof(TRequest).Name;
                //var userId = _currentUserService.UserId;
                //var userName = await _identityService.GetUserNameAsync(userId)?? "No Logged In";

                //_logger.LogWarning("CleanArchitecture Long Running Request: {Name} ({EllapsedMiliseconds}), {UserId} - {UserName} - {Request}",
                //    requestName, elapsedMiliseconds, userId, userName, request);
            }

            return response;
        }
    }
}
