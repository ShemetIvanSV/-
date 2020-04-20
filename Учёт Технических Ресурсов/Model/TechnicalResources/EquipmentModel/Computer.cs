using System.Collections.ObjectModel;
using Учёт_Технических_Ресурсов.Model.ComponentPartsModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    class Computer : TechnicalResourcesBaseModel
    {
        private ObservableCollection<Monitor> monitors;
        private CPU cPU;
        private ObservableCollection<RUM> rUM;
        private Motherboard motherboard;
        private OperatingSystem operatingSystem;
        private ObservableCollection<ApplicationProgram> applicationPrograms;

        public virtual ObservableCollection<Monitor> Monitor
        {
            get { return monitors; }
            set
            {
                OnPropertyChanged("Monitor");
                monitors = value;
            }
        }

        public virtual CPU CPU
        {
            get { return cPU; }
            set
            {
                OnPropertyChanged("CPU");
                cPU = value;
            }
        }

        public virtual ObservableCollection<RUM> RUM
        {
            get { return rUM; }
            set
            {
                OnPropertyChanged("RUM");
                rUM = value;
            }
        }

        public virtual Motherboard Motherboard
        {
            get { return motherboard; }
            set
            {
                OnPropertyChanged("Motherboard");
                motherboard = value;
            }
        }

        public virtual OperatingSystem OperatingSystem
        {
            get { return operatingSystem; }
            set
            {
                OnPropertyChanged("OperatingSystem");
                operatingSystem = value;
            }
        }

        public virtual ObservableCollection<ApplicationProgram> ApplicationPrograms
        {
            get { return applicationPrograms; }
            set
            {
                OnPropertyChanged("ApplicationPrograms");
                applicationPrograms = value;
            }
        }
    }
}
