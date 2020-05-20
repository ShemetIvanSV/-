using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    public class ComputerRepository : IEquipmentRepository<Computer>
    {
        private TechnicalResourcesContext Technicaldb { get;}

        public ComputerRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }

        public void Remove(Computer selectedCpu)
        {
            var dataContextComputers = Technicaldb.Computers;
            dataContextComputers.Attach(selectedCpu);
            dataContextComputers.Remove(selectedCpu);
            Technicaldb.SaveChanges();

        }

        public IEnumerable<Computer> Return()
        {
            var computers = Technicaldb.Computers.Include(c => c.CPU)
                                                     .Include(c => c.Monitors)
                                                     .Include(c => c.Motherboard)
                                                     .Include(c => c.OperatingSystem)
                                                     .Include(c => c.ApplicationPrograms)
                                                     .Include(c => c.RUM)
                                                     .Include(c => c.Printer);
            return computers;
        }

        public void SaveChange(IEnumerable<Computer> inputCPUs)
        {
            foreach (var computer in inputCPUs)
            {
                Technicaldb.Entry(computer).State = EntityState.Modified;
            }
            Technicaldb.SaveChanges();
        }
    }
}
