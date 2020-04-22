using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.ComponentPartsModel
{
    class CPU : TechnicalResourcesBaseModel
    {
        private int numberOfCores;
        private int processorFrequency;
        private Computer computer;
        private int computerId;

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

        public int NumberOfCores
        {
            get { return numberOfCores; }
            set
            {
                numberOfCores = value;
                OnPropertyChanged();
            }
        }

        public int ProcessorFrequency
        {
            get { return processorFrequency; }
            set
            {
                processorFrequency = value;
                OnPropertyChanged();
            }
        }

        public int ComputerId
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
