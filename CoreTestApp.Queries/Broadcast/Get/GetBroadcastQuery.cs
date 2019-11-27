using System;
using MediatR;

namespace CoreTestApp.Queries.Broadcast.Get
{
    public class GetBroadcastQuery : IRequest<BroadcastViewModel>
    {
        public Guid BroadcastId { get; set; }
    }
}
