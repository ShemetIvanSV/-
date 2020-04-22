using System.Windows;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.View;
namespace Учёт_Технических_Ресурсов
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var login = new Login();
            f.Navigate(login);
        }
    }
}
