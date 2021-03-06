﻿using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;
using OperatingSystem = Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel.OperatingSystem;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    class TechnicalResourcesContext : DbContext
    {
        static TechnicalResourcesContext()
        {
            Database.SetInitializer(new TechnicalInitializer());
        }
        public TechnicalResourcesContext() : base("TechnicalResourcesDataBase") { }
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
