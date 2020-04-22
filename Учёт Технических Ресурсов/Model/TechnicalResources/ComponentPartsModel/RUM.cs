using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.ComponentPartsModel
{
    class RUM : TechnicalResourcesBaseModel
    {
        private int rumFrequency;
        private int size;
        private Computer computer;
        private int? computerId;

        public int RumFrequency
        {
            get { return rumFrequency; }
            set
            {
                rumFrequency = value;
                OnPropertyChanged();
            }
        }

        public int Size
        {
            get { return size; }
            set
            {
                size = value;
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
