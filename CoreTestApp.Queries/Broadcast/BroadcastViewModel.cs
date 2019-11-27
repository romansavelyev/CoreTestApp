using System;
using CoreTestApp.Persistance.Models;

namespace CoreTestApp.Queries.Broadcast
{
    public class BroadcastViewModel
    {
        public Guid BroadcastId { get; set; }

        public BroadcastType BroadcastType { get; set; }

        public Guid BroadcastTypeId { get; set; }

        public DateTime? FirstOnline { get; set; }

        public static BroadcastViewModel ToViewModel(Persistance.Models.Broadcast broadcast)
        {
            return new BroadcastViewModel
            {
                BroadcastId = broadcast.BroadcastId,
                BroadcastTypeId = broadcast.BroadcastTypeId,
                FirstOnline = broadcast.FirstOnline
            };
        }
    }
}
