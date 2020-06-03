using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoreTestApp.Infrastructure.Repository;
using MediatR;

namespace CoreTestApp.Queries.Broadcast.Get
{
    public class GetAllBroadcastsQuery : IRequest<IEnumerable<Persistance.Models.Broadcast>>
    {
    }
    
    public class GetAllBroadcastsQueryHandler : IRequestHandler<GetAllBroadcastsQuery, IEnumerable<Persistance.Models.Broadcast>>
    {
        private readonly ISqlRepository<Persistance.Models.Broadcast> _repository;

        public GetAllBroadcastsQueryHandler(ISqlRepository<Persistance.Models.Broadcast> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Persistance.Models.Broadcast>> Handle(GetAllBroadcastsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
