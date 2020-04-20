using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel
{
    class OperatingSystem : TechnicalResourcesBaseModel
    {
        private int version;
        private Computer computer;
        private int? computerId;

        public override int Id
        {
            get { return base.Id; }
            set
            {
                OnPropertyChanged("Id");
                base.Id = value;
            }
        }

        public virtual Computer Computer
        {
            get { return computer; }
            set
            {
                OnPropertyChanged("Computer");
                computer = value;
            }
        }

        public int Version
        {
            get { return version; }
            set
            {
                OnPropertyChanged("Version");
                version = value;
            }
        }

        public int? ComputerId
        {
            get { return computerId; }
            set
            {
                OnPropertyChanged("ComputerId");
                ComputerId = value;
            }
        }
    }
}
