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

        public TypeMatrix Matrix
        {
            get { return matrix; }
            set
            {
                OnPropertyChanged("Matrix");
                matrix = value;
            }
        }
        public MonitorResolution MonitorResolution
        {
            get { return monitorResolution; }
            set
            {
                OnPropertyChanged("MonitorResolution");
                monitorResolution = value;
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
