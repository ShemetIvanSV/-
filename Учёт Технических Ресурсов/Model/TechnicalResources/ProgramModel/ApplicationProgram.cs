using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel
{
    class ApplicationProgram : TechnicalResourcesBaseModel
    {
        private int version;
        private Computer computer;

        public Computer Computer
        {
            get { return computer; }
            set
            {
                OnPropertyChanged("Computer");
                computer = value;
            }
        }
        public int Version
        {
            get { return version; }
            set
            {
                OnPropertyChanged("Version");
                version = value;
            }
        }
    }
}
