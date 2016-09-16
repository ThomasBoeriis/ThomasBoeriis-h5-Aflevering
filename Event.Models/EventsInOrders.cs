namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventsInOrders
    {
        public int Id { get; set; }

        public int FK_Event { get; set; }

        public int FK_Order { get; set; }

        public int Quantity { get; set; }

        public virtual Events Events { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
