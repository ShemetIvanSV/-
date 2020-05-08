using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    internal class MonitorRepository : IEquipmentRepository<Monitor>
    {
        public MonitorRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }

        private TechnicalResourcesContext Technicaldb { get; }

        public void Remove(Monitor selectedMonitor)
        {
            var dataContextMonitors = Technicaldb.Monitors;
            dataContextMonitors.Attach(selectedMonitor);
            dataContextMonitors.Remove(selectedMonitor);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<Monitor> Return()
        {
            var monitors = Technicaldb.Monitors.Include(m => m.Computer);
            return monitors;
        }

        public void SaveChange(IEnumerable<Monitor> inputMonitors)
        {
            foreach (var monitor in inputMonitors) Technicaldb.Entry(monitor).State = EntityState.Modified;
            Technicaldb.SaveChanges();
        }
    }
}