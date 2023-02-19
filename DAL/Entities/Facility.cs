using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public  class Facility
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
