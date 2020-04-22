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

        public virtual ObservableCollection<Monitor> Monitors
        {
            get { return monitors; }
            set
            {
                monitors = value;
                OnPropertyChanged();
            }
        }

        public virtual CPU CPU
        {
            get { return cPU; }
            set
            {
                cPU = value;
                OnPropertyChanged();
            }
        }

        public virtual ObservableCollection<RUM> RUM
        {
            get { return rUM; }
            set
            {
                rUM = value;
                OnPropertyChanged();
            }
        }

        public virtual Motherboard Motherboard
        {
            get { return motherboard; }
            set
            {
                motherboard = value;
                OnPropertyChanged();
            }
        }

        public virtual OperatingSystem OperatingSystem
        {
            get { return operatingSystem; }
            set
            {
                operatingSystem = value;
                OnPropertyChanged();
            }
        }

        public virtual ObservableCollection<ApplicationProgram> ApplicationPrograms
        {
            get { return applicationPrograms; }
            set
            {
                applicationPrograms = value;
                OnPropertyChanged();
            }
        }
    }
}
