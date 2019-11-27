using System;
using MediatR;

namespace CoreTestApp.Commands.Broadcast.Create
{
    public class CreateBroadcastCommand : IRequest<Guid>
    {
        public Guid BroadcastTypeId { get; set; }
        
        public string Title { get; set; }
    }
}
