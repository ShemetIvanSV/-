using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model
{
    abstract class EquipmentBaseModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime DateOfRecept { get; set; }
        public bool IsUsed { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
