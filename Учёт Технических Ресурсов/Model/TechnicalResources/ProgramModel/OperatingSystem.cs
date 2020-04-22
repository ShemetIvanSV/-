using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel
{
    class OperatingSystem : TechnicalResourcesBaseModel
    {
        private int version;
        private Computer computer;
        private int? computerId;

        [ForeignKey("Computer")]
        public override int Id
        {
            get { return base.Id; }
            set
            {
                base.Id = value;
                OnPropertyChanged();
            }
        }

        public virtual Computer Computer
        {
            get { return computer; }
            set
            {
                computer = value;
                OnPropertyChanged(nameof(Computer));
            }
        }

        public int Version
        {
            get { return version; }
            set
            {
                version = value;
                OnPropertyChanged(nameof(Version));
            }
        }

        public int? ComputerId
        {
            get { return computerId; }
            set
            {
                computerId = value;
                OnPropertyChanged(nameof(ComputerId));
            }
        }
    }
}
