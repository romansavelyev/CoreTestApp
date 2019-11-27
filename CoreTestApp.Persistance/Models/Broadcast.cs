using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTestApp.Persistance.Models
{
    [Table("Broadcast", Schema = "test")]
    public class Broadcast
    {
        public Guid BroadcastId { get; set; }
       
        public Guid BroadcastTypeId { get; set; }
        
        public string Title { get; set; }
        
        public BroadcastType BroadcastType { get; set; }

        public DateTime? FirstOnline { get; set; }
    }
}
