using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    class EquipmentContext : DbContext
    {
        public EquipmentContext() : base("EquipmentDataBase") { }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Printer> Printers { get; set; }
    }
}
