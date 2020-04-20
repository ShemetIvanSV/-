using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.ComponentPartsModel
{
    class RUM : TechnicalResourcesBaseModel
    {
        private int rumFrequency;
        private int size;
        private Computer computer;

        public int RumFrequency
        {
            get { return rumFrequency; }
            set
            {
                OnPropertyChanged("RumFrequency");
                rumFrequency = value;
            }
        }

        public int Size
        {
            get { return size; }
            set
            {
                OnPropertyChanged("Size");
                size = value;
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
