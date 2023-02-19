using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Facility")]
        public int FacilityId { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
