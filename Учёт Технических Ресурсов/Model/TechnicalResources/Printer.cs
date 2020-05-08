using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    public enum PrintingTechnology
    {
        matrix,
        inkjet,
        laser
    }

    public class Printer : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int computerId;
        private int numberOfColors;
        private PrintingTechnology printingTechnology;

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

        public PrintingTechnology PrintingTechnology
        {
            get => printingTechnology;
            set
            {
                printingTechnology = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfColors
        {
            get => numberOfColors;
            set
            {
                numberOfColors = value;
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