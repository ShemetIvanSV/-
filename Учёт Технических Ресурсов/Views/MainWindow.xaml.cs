using MahApps.Metro.Controls;
using Учёт_Технических_Ресурсов.ViewModel;

namespace Учёт_Технических_Ресурсов
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NavigateVM();
        }
    }
}
