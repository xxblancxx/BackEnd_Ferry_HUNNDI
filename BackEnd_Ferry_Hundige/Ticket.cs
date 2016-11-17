namespace BackEnd_Ferry_Hundige
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int RefCustomer { get; set; }

        public int ReservationForTicket { get; set; }

        public int Transportation { get; set; }

        public int Type { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
