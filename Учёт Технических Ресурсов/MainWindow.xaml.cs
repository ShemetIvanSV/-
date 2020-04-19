using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using(var inventory = new EquipmentContext())
            {
                inventory.Monitors.Add(new Monitor() 
                {Location = "Бухгалтерия",
                DateOfRecept = DateTime.Now,
                IsUsed = true,
                Matrix = TypeMatrix.OLED,
                Price = 20000,
                Description = "Монитор хороший",
                MonitorResolution = new MonitorResolution(1920,180),
                Computer = null
                });
                inventory.SaveChanges();
            }
        }
    }
}
