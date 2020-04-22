namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    enum TypeMatrix
    {
        IPS,
        PLS,
        TNF,
        OLED
    }

    class Monitor : TechnicalResourcesBaseModel
    {
        private TypeMatrix matrix;
        private MonitorResolution monitorResolution;
        private Computer computer;
        private int? computerId;

        public TypeMatrix Matrix
        {
            get { return matrix; }
            set
            {
                matrix = value;
                OnPropertyChanged();
            }
        }

        public MonitorResolution MonitorResolution
        {
            get { return monitorResolution; }
            set
            {
                monitorResolution = value;
                OnPropertyChanged();
            }
        }

        public int? ComputerId
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
