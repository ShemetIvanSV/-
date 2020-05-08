using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    internal class PrinterRepository : IEquipmentRepository<Printer>
    {
        public PrinterRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }

        private TechnicalResourcesContext Technicaldb { get; }

        public void Remove(Printer selectedPrinter)
        {
            var dataContextPrinters = Technicaldb.Printers;
            dataContextPrinters.Attach(selectedPrinter);
            dataContextPrinters.Remove(selectedPrinter);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<Printer> Return()
        {
            var printers = Technicaldb.Printers.Include(p => p.Computer);
            return printers;
        }

        public void SaveChange(IEnumerable<Printer> inputPrinters)
        {
            foreach (var printer in inputPrinters) Technicaldb.Entry(printer).State = EntityState.Modified;
            Technicaldb.SaveChanges();
        }
    }
}