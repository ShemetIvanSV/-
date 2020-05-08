using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources
{
    public class CPU : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int computerId;
        private int numberOfCores;
        private int processorFrequency;

        public int NumberOfCores
        {
            get => numberOfCores;
            set
            {
                numberOfCores = value;
                OnPropertyChanged();
            }
        }

        public int ProcessorFrequency
        {
            get => processorFrequency;
            set
            {
                processorFrequency = value;
                OnPropertyChanged();
            }
        }

        [Key]
        [ForeignKey("Computer")]
        public int ComputerId
        {
            get => computerId;
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        public Computer Computer
        {
            get => computer;
            set
            {
                computer = value;
                OnPropertyChanged();
            }
        }
    }
}