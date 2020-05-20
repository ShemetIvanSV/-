using System;
using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;
using OperatingSystem = Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel.OperatingSystem;

namespace Учёт_Технических_Ресурсов.Model
{
    class TechnicalInitializer : CreateDatabaseIfNotExists<TechnicalResourcesContext>
    {
        protected override void Seed(TechnicalResourcesContext context)
        {
            var computers = new List<Computer>
            {
                new Computer{Title="AsusL540", Price=56990, PicturePath=new Uri(@"/Resources/Asus.jpg", UriKind.Relative).ToString(), Description=Description},
                new Computer{Title="MSICubiM8GL", Price=30000, PicturePath=new Uri(@"/Resources/MSI.jpg", UriKind.Relative).ToString(), Description=Description},
                new Computer{Title="LenovoV330", Price=28900, PicturePath=new Uri(@"/Resources/Lenovo.jpg", UriKind.Relative).ToString(), Description=Description},
                new Computer{Title="AcerAspireA515", Price=40000, PicturePath=new Uri(@"/Resources/Acer.jpg", UriKind.Relative).ToString(), Description=Description},
                new Computer{Title="MacBookPro2020", Price=170000, PicturePath=new Uri(@"/Resources/Mac.png", UriKind.Relative).ToString(), Description=Description},
                new Computer{Title="HP260G3", Price=43000, PicturePath=new Uri(@"/Resources/HP.jpg", UriKind.Relative).ToString(), Description=Description},
                new Computer{Title="DellPrecision3240", Price=70000,  PicturePath=new Uri(@"/Resources/Dell.jpg", UriKind.Relative).ToString(), Description=Description},
            };

            var monitors = new List<Monitor>
            {
                new Monitor{Title="AsusMonitor", Price=6990, PicturePath=new Uri(@"/Resources/1.jpg", UriKind.Relative).ToString(), ComputerId=1, Description=Description},
                new Monitor{Title="MsiMonitor", Price=8900, PicturePath=new Uri(@"/Resources/2.jpg", UriKind.Relative).ToString(), ComputerId=2, Description=Description},
                new Monitor{Title="LenovoMonitor", Price=7690, PicturePath=new Uri(@"/Resources/3.jpg", UriKind.Relative).ToString(), ComputerId=3, Description=Description},
                new Monitor{Title="AcerMonitor", Price=5390, PicturePath=new Uri(@"/Resources/4.jpg", UriKind.Relative).ToString(), ComputerId=4, Description=Description},
                new Monitor{Title="AcerMonitor", Price=18000, PicturePath=new Uri(@"/Resources/5.jpg", UriKind.Relative).ToString(), ComputerId=4, Description=Description},
                new Monitor{Title="HpMonitor", Price=5990, PicturePath=new Uri(@"/Resources/6.jpg", UriKind.Relative).ToString(), ComputerId=6, Description=Description},
                new Monitor{Title="DellMonitor", Price=8990, PicturePath=new Uri(@"/Resources/7.jpg", UriKind.Relative).ToString(), ComputerId=7, Description=Description},
            };

            var cpus = new List<CPU>
            {
                new CPU{Title="AsusCpu", Price=3000, ComputerId=1, Description=Description},
                new CPU{Title="MsiCpu", Price=6000,  ComputerId=2, Description=Description},
                new CPU{Title="LenovoCpu", Price=8990, ComputerId=3, Description=Description},
                new CPU{Title="AcerCpu", Price=20000, ComputerId=4, Description=Description},
                new CPU{Title="MacCpu", Price=30000, ComputerId=5, Description=Description},
                new CPU{Title="HpCpu", Price=7000, ComputerId=6, Description=Description},
                new CPU{Title="DellCpu", Price=4000, ComputerId=7, Description=Description},
            };

            var motherboards = new List<Motherboard>
            {
                new Motherboard{Title="AsusMotherBoard", Price=7000, ComputerId=1, Description=Description},
                new Motherboard{Title="MsiMotherboard", Price=7400, ComputerId=2, Description=Description},
                new Motherboard{Title="LenovoMotherboard", Price=4500, ComputerId=3, Description=Description},
                new Motherboard{Title="AserMotherboard", Price=5400, ComputerId=4, Description=Description},
                new Motherboard{Title="MacMotherboard", Price=6599, ComputerId=5, Description=Description},
                new Motherboard{Title="HpMotherboard", Price=6077, ComputerId=6, Description=Description},
                new Motherboard{Title="DellMotherboard", Price=6666, ComputerId=7, Description=Description},
            };

            var printers = new List<Printer>
            {
                new Printer{Title="AsusPrinter", Price=8000, PicturePath=new Uri(@"/Resources/p1.jpg", UriKind.Relative).ToString(), ComputerId=1, Description=Description},
                new Printer{Title="MsiPrinter", Price=6000, PicturePath=new Uri(@"/Resources/p2.jpg", UriKind.Relative).ToString(), ComputerId=2, Description=Description},
                new Printer{Title="LenovoPrinter", Price=12000, PicturePath=new Uri(@"/Resources/p3.jpg", UriKind.Relative).ToString(), ComputerId=3, Description=Description},
            };

            var apps = new List<ApplicationProgram>
            {
                new ApplicationProgram{ Title="MicrosoftOffice2016", Price=3000, ComputerId=1, Description=Description},
                new ApplicationProgram{ Title="MicrosoftOffice2010", Price=3000, ComputerId=2, Description=Description },
                new ApplicationProgram{ Title="Photoshop2020", Price=4000, ComputerId=3, Description=Description},
                new ApplicationProgram{ Title="GoogleChrome", Price=0, ComputerId=4, Description=Description},
                new ApplicationProgram{ Title="MicrosoftOffice2007", Price=5000, ComputerId=5, Description=Description},
                new ApplicationProgram{ Title="PhotoshopLite", Price=12000, ComputerId=6, Description=Description},
                new ApplicationProgram{ Title="MicrosoftOffice2012", Price=6000, ComputerId=7, Description=Description},
            };
            var os = new List<OperatingSystem>
            {
                new OperatingSystem{Title="Windows10", Price=10000, ComputerId=1, Description=Description},
                new OperatingSystem{Title="Windows7Proffesional", Price=3000, ComputerId=2, Description=Description},
                new OperatingSystem{Title="Windows7Proffesional", Price=3000, ComputerId=3, Description=Description},
                new OperatingSystem{Title="Windows10", Price=10000, ComputerId=4, Description=Description},
                new OperatingSystem{Title="Macintosh", Price=0, ComputerId=5, Description=Description},
                new OperatingSystem{Title="Windows10", Price=10000, ComputerId=6, Description=Description},
                new OperatingSystem{Title="Windows10", Price=10000, ComputerId=7, Description=Description},
            };
            var rums = new List<RUM>
            {
                new RUM{Title="AsusRUM", Price=3000, ComputerId=1, Description=Description},
                new RUM{Title="MsiRUM", Price=3000, ComputerId=2, Description=Description},
                new RUM{Title="LenovoRUM", Price=3000, ComputerId=3, Description=Description},
                new RUM{Title="AcerRUM", Price=3000, ComputerId=4, Description=Description},
                new RUM{Title="MacRUM", Price=3000, ComputerId=5, Description=Description},
                new RUM{Title="HpRUM", Price=3000, ComputerId=6, Description=Description},
                new RUM{Title="DellRUM", Price=3000, ComputerId=7, Description=Description},
            };
            computers.ForEach(computer => context.Computers.Add(computer));
            context.SaveChanges();
            rums.ForEach(rum => context.RUMs.Add(rum));
            os.ForEach(o => context.OperatingSystems.Add(o));
            cpus.ForEach(cpu => context.CPUs.Add(cpu));
            apps.ForEach(app => context.ApplicationPrograms.Add(app));
            printers.ForEach(printer => context.Printers.Add(printer));
            motherboards.ForEach(motherboard => context.Motherboards.Add(motherboard));
            monitors.ForEach(monitor => context.Monitors.Add(monitor));
            context.SaveChanges();
        }
        private string Description
        {
            get
            {
                return "Равным образом постоянное информационно-пропагандистское обеспечение " +
                    "нашей деятельности позволяет выполнять важные задания по разработке" +
                    " направлений прогрессивного развития. Задача организации, в особенности " +
                    "же консультация с широким активом требуют определения и уточнения позиций," +
                    " занимаемых участниками в отношении поставленных задач. Товарищи! дальнейшее " +
                    "развитие различных форм деятельности позволяет оценить значение дальнейших направлений" +
                    " развития. Значимость этих проблем настолько очевидна, что рамки и место обучения" +
                    " кадров влечет за собой процесс внедрения и модернизации систем массового участия. " +
                    "Идейные соображения высшего порядка, а также постоянное информационно-пропагандистское " +
                    "обеспечение нашей деятельности обеспечивает широкому кругу (специалистов) участие в формировании " +
                    "дальнейших направлений развития.";
            }
        }
    }
}
