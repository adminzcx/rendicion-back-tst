using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application._Common.Handlers
{

    public abstract class QueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        protected readonly IAsyncUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;

        public QueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected TResponse Map<T>(T data)
        {
            return _mapper.Map<TResponse>(data);
        }
    }
}
