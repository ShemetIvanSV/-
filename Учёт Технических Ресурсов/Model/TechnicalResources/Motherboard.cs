using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources
{
    public class Motherboard : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int computerId;
        private bool overclockingFunction;

        public bool OverclockingFunction
        {
            get => overclockingFunction;
            set
            {
                overclockingFunction = value;
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

        public override string ToString()
        {
            return Title;
        }
    }
}