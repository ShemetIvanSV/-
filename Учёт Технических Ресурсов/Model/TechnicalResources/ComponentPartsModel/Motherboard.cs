using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.ComponentPartsModel
{
    class Motherboard : TechnicalResourcesBaseModel
    {
        private bool overclockingFunction;
        private Computer computer;

        [ForeignKey("Computer")]
        public override int Id
        {
            get { return base.Id; }
            set
            {
                OnPropertyChanged("Id");
                base.Id = value;
            }
        }

        public bool OverclockingFunction
        {
            get { return overclockingFunction; }
            set
            {
                OnPropertyChanged("OverclockingFunction");
                overclockingFunction = value;
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
    }
}
