using System.Collections.Generic;
using Учёт_Технических_Ресурсов.Model;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    public interface IEquipmentRepository<T> where T : TechnicalResourcesBaseModel
    {
        IEnumerable<T> Return();
        void SaveChange(IEnumerable<T> inputCPUs);
        void Remove(T selectedCpu);
    }
}
