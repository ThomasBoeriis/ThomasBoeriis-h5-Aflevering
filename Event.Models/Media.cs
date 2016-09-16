namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Media
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int FK_Type { get; set; }

        public int FK_Event { get; set; }

        public virtual Events Events { get; set; }

        public virtual MediaTypes MediaTypes { get; set; }
    }
}
