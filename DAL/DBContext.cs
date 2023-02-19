using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DBContext() {}

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>().HasData(
                new Facility
                {
                    Id = 1,
                    Name = "test1",
                    Capacity = 100
                }
                ,
                 new Facility
                 {
                     Id = 2,
                     Name = "test2",
                     Capacity = 150
                 }
                ,
                 new Facility
                 {
                     Id = 3,
                     Name = "test3",
                     Capacity = 200
                 }
                );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    Id = 1,
                    Name = "Equip1",
                    Area = 20
                },
                new Equipment
                {
                    Id = 2,
                    Name = "Equip2",
                    Area = 15
                },
                new Equipment
                {
                    Id = 3,
                    Name = "Equip3",
                    Area = 10
                }
                );
            modelBuilder.Entity<Contract>().HasData(
                new Contract
                {
                    Id = 1,
                    FacilityId = 1,
                    EquipmentId = 1,
                    Quantity = 1,
                },
                new Contract
                {
                    Id = 2,
                    FacilityId = 1,
                    EquipmentId = 2,
                    Quantity = 2,
                },
                new Contract
                {
                    Id = 3,
                    FacilityId = 2,
                    EquipmentId = 3,
                    Quantity = 3,
                }
                );
        }

    }
}
