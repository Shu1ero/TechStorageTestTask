using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
