namespace BackEnd_Ferry_Hundige
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketType")]
    public partial class TicketType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int PriceOfTicket { get; set; }

        public virtual Price Price { get; set; }
    }
}
