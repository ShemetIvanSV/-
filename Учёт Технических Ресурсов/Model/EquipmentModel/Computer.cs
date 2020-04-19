using System.Collections.Generic;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    class Computer : EquipmentBaseModel
    {
        public string Manufacturer { get; set; }
        public string OS { get; set; }
        public List<Monitor> Monitor { get; set; }
    }
}
