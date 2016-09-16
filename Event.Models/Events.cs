using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Event.Models
{

    public partial class Events
    {
        public Events()
        {
            EventsInOrders = new HashSet<EventsInOrders>();
            Media = new HashSet<Media>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

        public decimal Price { get; set; }

        public int NoOfTickets { get; set; }
        
        [DataType(DataType.MultilineText)]
        
        public string Description { get; set; }

        public int FK_Category { get; set; }

        public int FK_Location { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Location Location { get; set; }

        
        public virtual ICollection<EventsInOrders> EventsInOrders { get; set; }

        
        public virtual ICollection<Media> Media { get; set; }
    }
}
