using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.ComponentPartsModel
{
    class CPU : TechnicalResourcesBaseModel
    {
        private int numberOfCores;
        private int processorFrequency;
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
        public int NumberOfCores
        {
            get { return numberOfCores; }
            set
            {
                OnPropertyChanged("NumberOfCores");
                numberOfCores = value;
            }
        }

        public int ProcessorFrequency
        {
            get { return processorFrequency; }
            set
            {
                OnPropertyChanged("ProcessorFrequency");
                processorFrequency = value;
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
