using System;
using System.Threading;
using System.Threading.Tasks;
using CoreTestApp.Infrastructure.Repository;
using MediatR;

namespace CoreTestApp.Commands.Broadcast.Create
{
    public class CreateBroadcastCommand : IRequest<Guid>
    {
        public Guid BroadcastTypeId { get; set; }

        public string Title { get; set; }
    }

    public class CreateBroadcastCommandHandler : IRequestHandler<CreateBroadcastCommand, Guid>
    {
        private readonly ISqlRepository<Persistance.Models.Broadcast> _repository;

        public CreateBroadcastCommandHandler(ISqlRepository<Persistance.Models.Broadcast> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateBroadcastCommand request, CancellationToken cancellationToken)
        {
            var broadcast = new Persistance.Models.Broadcast
            {
                BroadcastTypeId = request.BroadcastTypeId,
                Title = request.Title,
                FirstOnline = DateTime.Now
            };

            await _repository.CreateAsync(broadcast);
            
            await _repository.SaveChangesAsync(cancellationToken);

            return broadcast.BroadcastId;
        }
    }
}
