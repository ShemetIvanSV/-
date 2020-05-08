using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.Model
{
    public class RUM : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int? computerId;
        private int? rumFrequency;
        private int? size;

        public int? RumFrequency
        {
            get => rumFrequency;
            set
            {
                rumFrequency = value;
                OnPropertyChanged();
            }
        }

        public int? Size
        {
            get => size;
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }

        public int? ComputerId
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