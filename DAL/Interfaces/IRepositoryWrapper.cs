using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepositoryWrapper
    {
        IFacilityRepository Facility { get; }
        IEquipmentRepository Equipment { get; }
        IContractRepository Contract { get; }
        void Save();
    }
}
