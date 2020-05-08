using System.ComponentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    public enum TypeMatrix
    {
        [Description("IPS")]
        IPS,
        [Description("PLS")]
        PLS,
        [Description("TNF")]
        TNF,
        [Description("OLED")]
        OLED
    }

    public class Monitor : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int? computerId;
        private TypeMatrix matrix;
        private int? monitorResolution;

        public int? ComputerId
        {
            get => computerId;
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        public TypeMatrix Matrix
        {
            get => matrix;
            set
            {
                matrix = value;
                OnPropertyChanged();
            }
        }

        public int? MonitorResolution
        {
            get => monitorResolution;
            set
            {
                monitorResolution = value;
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