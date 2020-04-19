using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    enum TypeMatrix
    {
        IPS,
        PLS,
        TNF,
        OLED
    }
    class Monitor : EquipmentBaseModel
    {
        public TypeMatrix Matrix { get; set; }
        public MonitorResolution MonitorResolution { get; set; }
        public Computer Computer { get; set; }
    }
}
