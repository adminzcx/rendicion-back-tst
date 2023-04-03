
using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain._Common;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application._Common.Handlers
{

    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        protected readonly IAsyncUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public CommandHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public CommandHandler(IAsyncUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public async Task<T> FindByCode<T>(string code)
            where T : BaseNameCodeEntity
        {
            var result = await _unitOfWork
                        .Repository<T>()
                        .SingleOrDefaultAsync(new ByCodeSpecification<T>(code));

            Guard.Against.Null(result, typeof(T).Name);

            return result;
        }

        public async Task<T> FindById<T>(int id)
          where T : BaseEntity
        {
            var result = await _unitOfWork
                        .Repository<T>()
                        .GetByIdAsync(id);

            Guard.Against.Null(result, typeof(T).Name);

            return result;
        }

    }

    public abstract class CommandHandler<TRequest> : CommandHandler<TRequest, Unit>
     where TRequest : IRequest<Unit>
    {
        public CommandHandler(IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
        public CommandHandler(IAsyncUnitOfWork unitOfWork)
           : base(unitOfWork)
        {
        }
    }
}
