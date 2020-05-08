using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    class CpuRepository:IEquipmentRepository<CPU>
    {
        private TechnicalResourcesContext Technicaldb { get; }

        public CpuRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }

        public void Remove(CPU selectedCpu)
        {
            var dataContextCpu = Technicaldb.CPUs;
            dataContextCpu.Attach(selectedCpu);
            dataContextCpu.Remove(selectedCpu);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<CPU> Return()
        {
            var cpus = Technicaldb.CPUs.Include(cpu => cpu.Computer);
            return cpus;
        }

        public void SaveChange(IEnumerable<CPU> inputCPUs)
        {
            foreach (var cpu in inputCPUs)
            {
                Technicaldb.Entry(cpu).State = EntityState.Modified;
            }
            Technicaldb.SaveChanges();
        }
    }
}
