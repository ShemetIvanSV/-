using System.Data.Entity;
using System.Collections.Generic;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using OperatingSystem = Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel.OperatingSystem;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    class OperatingSystemRepository : IEquipmentRepository<OperatingSystem>
    {
        private TechnicalResourcesContext Technicaldb { get; }

        public OperatingSystemRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }
        public void Remove(OperatingSystem selectedOperatingSystem)
        {
            var dataContextOS = Technicaldb.OperatingSystems;
            dataContextOS.Attach(selectedOperatingSystem);
            dataContextOS.Remove(selectedOperatingSystem);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<OperatingSystem> Return()
        {
            var operatingSystems = Technicaldb.OperatingSystems.Include(os => os.Computer);
            return operatingSystems;
        }

        public void SaveChange(IEnumerable<OperatingSystem> inputOperatingSystems)
        {
            foreach (var operatingSystem in inputOperatingSystems)
                Technicaldb.Entry(operatingSystem).State = EntityState.Modified;
            Technicaldb.SaveChanges();
        }
    }
}
