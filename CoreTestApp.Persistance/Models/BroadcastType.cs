using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTestApp.Persistance.Models
{
    [Table("BroadcastType", Schema = "test")]
    public class BroadcastType
    {
        public Guid BroadcastTypeId { get; set; }
        
        public string Name { get; set; }
    }
}
