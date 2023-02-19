using DAL.Entities;

namespace Services
{
    public interface IStorageService
    {
        void CreateContract(int facilityId, int equipmentId, int quantity);
        List<Contract> GetContracts();

        void DeleteContract(int contractId);

        void UpdateContract(Contract contract);
    }
}
