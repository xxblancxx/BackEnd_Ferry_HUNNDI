namespace BackEnd_Ferry_Hundige
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public bool IsReserve { get; set; }

        public int RefDeparture { get; set; }

        public int ReservationNumber { get; set; }

        public virtual Departure Departure { get; set; }
    }
}
