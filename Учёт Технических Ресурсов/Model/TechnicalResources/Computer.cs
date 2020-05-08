using System.Collections.ObjectModel;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources
{
    public class Computer : TechnicalResourcesBaseModel
    {
        private CPU cPU;
        private Motherboard motherboard;
        private OperatingSystem operatingSystem;
        private Printer printer;

        public int? MonitorId { get; set; }

        public int? RUMId { get; set; }

        public int? ApplicationProgramsId { get; set; }


        public Motherboard Motherboard
        {
            get => motherboard;
            set
            {
                motherboard = value;
                OnPropertyChanged();
            }
        }

        public OperatingSystem OperatingSystem
        {
            get => operatingSystem;
            set
            {
                operatingSystem = value;
                OnPropertyChanged();
            }
        }

        public CPU CPU
        {
            get => cPU;
            set
            {
                cPU = value;
                OnPropertyChanged();
            }
        }

        public Printer Printer
        {
            get => printer;
            set
            {
                printer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ApplicationProgram> ApplicationPrograms { get; set; }

        public ObservableCollection<RUM> RUM { get; set; }

        public ObservableCollection<Monitor> Monitors { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}