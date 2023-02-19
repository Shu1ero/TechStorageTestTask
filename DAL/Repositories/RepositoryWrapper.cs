using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DBContext _dBContext;
        private IFacilityRepository _facilityRepository;
        private IEquipmentRepository _equipmentRepository;
        private IContractRepository _contractRepository;

        public IFacilityRepository Facility
        {
            get
            {
                if (_facilityRepository == null)
                {
                    _facilityRepository = new FacilityRepository(_dBContext);
                }
                return _facilityRepository;
            }
        }

        public IEquipmentRepository Equipment
        {
            get
            {
                if (_equipmentRepository == null)
                {
                    _equipmentRepository = new EquipmentRepository(_dBContext);
                }
                return _equipmentRepository;
            }
        }

        public IContractRepository Contract
        {
            get
            {
                if (_contractRepository == null)
                {
                    _contractRepository = new ContractRepository(_dBContext);
                }
                return _contractRepository;
            }
        }
        public RepositoryWrapper(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Save()
        {
            _dBContext.SaveChanges();
        }
    }
}
