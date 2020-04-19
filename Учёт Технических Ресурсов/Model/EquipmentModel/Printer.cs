using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    public enum PrintingTechnology
    {
        matrix, inkjet, laser
    }
    class Printer : EquipmentBaseModel
    {
        public PrintingTechnology PrintingTechnology { get; set; }
        public int NumberOfColors { get; set; }
    }
}
