using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application._Common.Behaviours
{

    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;

        private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;
            var userName = string.Empty;

            //if (userId != 0)
            //{
            //    userName = await _identityService.GetUserNameAsync(userId);
            //}

            _logger.LogInformation("Prome Viáticos - Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName, request);
        }
    }
}
