namespace BackEnd_Ferry_Hundige
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ferry")]
    public partial class Ferry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ferry()
        {
            Departures = new HashSet<Departure>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public bool IsReserve { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int PeopleCapacity { get; set; }

        public int VehicleCapacity { get; set; }

        public int WeightCapacityInKg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departure> Departures { get; set; }
    }
}
