﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using MotorcycleWebShop.Application.Common.Interfaces;

namespace MotorcycleWebShop.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public RequestLogger(
            ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            //var requestName = typeof(TRequest).Name;
            //var userId = _currentUserService.UserId;
            //var userName = await _identityService.GetUserNameAsync(userId);

            //_logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@UserName} @{Request}",
            //    requestName, userId, userName, request);
        }
    }
}
