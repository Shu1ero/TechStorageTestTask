using DAL.Entities;
using DAL.Interfaces;
using System.Net;

namespace Services
{
    public class StorageService : IStorageService
    {
        private readonly IRepositoryWrapper _repository;

        public StorageService(IRepositoryWrapper repository) 
        { 
            _repository = repository;
        }
        public void CreateContract(int facilityId, int equipmentId, int quantity)
        {
            var contract = new Contract
            {
                FacilityId = facilityId,
                EquipmentId = equipmentId,
                Quantity = quantity
            };


            if (CanEquipmentFit(contract))
            {
                _repository.Contract.Create(contract);
                _repository.Save();
            }
            else throw new Exception("There is no place in this facility");

        }

        public List<Contract> GetContracts()
        {
            return _repository.Contract.FindAll();
        }

        public void DeleteContract(int contractId) 
        {
            var contract = _repository.Contract.FindAll().Where(_ => _.Id == contractId).FirstOrDefault();
            if (contract != null) 
            {
                _repository.Contract.Delete(contract);
                _repository.Save();
            }
            else
            {
                throw new Exception("There is no contract with this id!");
            }
            
        }

        public void UpdateContract(Contract contract) 
        {
            if (CanEquipmentFit(contract))
            {
                _repository.Contract.Update(contract);
                _repository.Save();
            }
            else throw new Exception("There is no place in this facility");
        }

        public bool CanEquipmentFit(Contract contract)
        {
            var facilityCapacity = 0.0;

            if (_repository.Facility.FindAll().Where(x => x.Id == contract.FacilityId).FirstOrDefault() != null)
            {
                facilityCapacity = _repository.Facility.FindAll().Where(x => x.Id == contract.FacilityId).FirstOrDefault().Capacity;
            }
            else throw new Exception("There is no such facility!");

            var usedSpace = 0.0;

            var contracts = new List<Contract>();

            if (contract.Id != null)
            {
                contracts = _repository.Contract.FindAll().Where(x => x.FacilityId == contract.FacilityId).Where(x => x.Id != contract.Id).ToList();
            }
            else
            {
                contracts =  _repository.Contract.FindAll().Where(x => x.FacilityId == contract.FacilityId).ToList();
            }

            foreach (var item in contracts)
            {
                usedSpace += _repository.Equipment.FindAll().Where(x => x.Id == item.EquipmentId).First().Area * item.Quantity;
            }

            var equipment = _repository.Equipment.FindAll().Where(x => x.Id == contract.EquipmentId).FirstOrDefault();

            if (facilityCapacity - usedSpace < equipment.Area * contract.Quantity)
            {
                return false;
            }
            else return true;
        }
    }
}