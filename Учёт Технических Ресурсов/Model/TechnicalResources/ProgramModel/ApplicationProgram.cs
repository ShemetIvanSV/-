using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel
{
    class ApplicationProgram : TechnicalResourcesBaseModel
    {
        private int version;
        private Computer computer;
        private int computerId;

        public int ComputerId
        {
            get { return computerId; }
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        public Computer Computer
        {
            get { return computer; }
            set
            {
                computer = value;
                OnPropertyChanged();
            }
        }
        public int Version
        {
            get { return version; }
            set
            {
                version = value;
                OnPropertyChanged();
            }
        }
    }
}
