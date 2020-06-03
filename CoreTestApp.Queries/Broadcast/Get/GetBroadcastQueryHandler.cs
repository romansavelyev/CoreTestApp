using System;
using System.Threading;
using System.Threading.Tasks;
using CoreTestApp.Infrastructure.Repository;
using CoreTestApp.Queries.Exceptions;
using MediatR;

namespace CoreTestApp.Queries.Broadcast.Get
{
    public class GetBroadcastQuery : IRequest<BroadcastViewModel>
    {
        public Guid BroadcastId { get; set; }
    }
    
    public class GetBroadcastQueryHandler : IRequestHandler<GetBroadcastQuery, BroadcastViewModel>
    {
        private readonly ISqlRepository<Persistance.Models.Broadcast> _repository;

        public GetBroadcastQueryHandler(ISqlRepository<Persistance.Models.Broadcast> repository)
        {
            _repository = repository;
        }

        public async Task<BroadcastViewModel> Handle(GetBroadcastQuery request, CancellationToken cancellationToken)
        {
            var broadcast = await _repository
                .GetByIdAsync(request.BroadcastId);

            var broadcastViewModel = BroadcastViewModel.ToViewModel(broadcast);

            if (broadcastViewModel == null)
            {
                throw new NotFoundException($"Entity {nameof(Broadcast)} with id: {request.BroadcastId} not found.");
            }

            return broadcastViewModel;
        }
    }
}
