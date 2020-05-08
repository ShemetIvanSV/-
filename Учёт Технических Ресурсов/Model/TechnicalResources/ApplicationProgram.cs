namespace Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel
{
    public class ApplicationProgram : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int? computerId;
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