using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel
{
    public class OperatingSystem : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int computerId;
        private int version;

        public int Version
        {
            get => version;
            set
            {
                version = value;
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