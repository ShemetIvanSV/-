using System;
using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    internal class RumRepository : IEquipmentRepository<RUM>
    {
        private TechnicalResourcesContext Technicaldb { get; }

        public RumRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }
        public void Remove(RUM selectedRum)
        {
            var dataContextRUMs = Technicaldb.RUMs;
            dataContextRUMs.Attach(selectedRum);
            dataContextRUMs.Remove(selectedRum);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<RUM> Return()
        {
            var RUMs = Technicaldb.RUMs.Include(rum => rum.Computer);
            return RUMs;
        }

        public void SaveChange(IEnumerable<RUM> inputRUMs)
        {
            foreach (var rum in inputRUMs) Technicaldb.Entry(rum).State = EntityState.Modified;
            Technicaldb.SaveChanges();
        }
    }
}
