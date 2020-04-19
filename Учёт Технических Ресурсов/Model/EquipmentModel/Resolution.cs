using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    struct MonitorResolution
    {
        public MonitorResolution(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
