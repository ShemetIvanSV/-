using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    internal class MotherboardRepository : IEquipmentRepository<Motherboard>
    {
        public MotherboardRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }

        private TechnicalResourcesContext Technicaldb { get; }

        public void Remove(Motherboard selectedMotherboard)
        {
            var dataContextMotherboards = Technicaldb.Motherboards;
            dataContextMotherboards.Attach(selectedMotherboard);
            dataContextMotherboards.Remove(selectedMotherboard);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<Motherboard> Return()
        {
            var motherboards = Technicaldb.Motherboards.Include(m => m.Computer);
            return motherboards;
        }

        public void SaveChange(IEnumerable<Motherboard> inputMotherboards)
        {
            foreach (var motherboard in inputMotherboards) Technicaldb.Entry(motherboard).State = EntityState.Modified;
            Technicaldb.SaveChanges();
        }
    }
}