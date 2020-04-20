using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;
using OperatingSystem = Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel.OperatingSystem;

namespace Учёт_Технических_Ресурсов
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using(var technicalResources = new TechnicalResourcesContext())
            {
                var computers = technicalResources.Computers;
                var os = new OperatingSystem()
                {
                    Title = "windows",
                    Location = "отдел2"
                };
                var computer = new Computer()
                {
                    Location = "Отдел1",
                    Title = "comp1",
                    OperatingSystem = os
                };
                technicalResources.Computers.Add(computer);
                technicalResources.SaveChanges();
            }
        }
    }
}
