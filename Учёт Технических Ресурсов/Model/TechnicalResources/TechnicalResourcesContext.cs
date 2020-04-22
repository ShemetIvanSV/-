using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Учёт_Технических_Ресурсов.Model.ComponentPartsModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;
using OperatingSystem = Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel.OperatingSystem;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    class TechnicalResourcesContext : DbContext
    {
        public TechnicalResourcesContext() : base("TechnicalResourcesDB") { }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<RUM> RUMs { get; set; }
        public DbSet<ApplicationProgram> ApplicationPrograms { get; set; }
        public DbSet<OperatingSystem> OperatingSystems { get; set; }
    }
}
