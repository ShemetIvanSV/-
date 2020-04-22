using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.ComponentPartsModel
{
    class Motherboard : TechnicalResourcesBaseModel
    {
        private bool overclockingFunction;
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

        public bool OverclockingFunction
        {
            get { return overclockingFunction; }
            set
            {
                overclockingFunction = value;
                OnPropertyChanged();
            }
        }

        public int? ComputerId
        {
            get { return computerId; }
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        public virtual Computer Computer
        {
            get { return computer; }
            set
            {
                computer = value;
                OnPropertyChanged();
            }
        }
    }
}
