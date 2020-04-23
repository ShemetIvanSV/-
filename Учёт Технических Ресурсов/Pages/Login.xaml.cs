using System.Windows.Controls;
using Учёт_Технических_Ресурсов.ViewModel;

namespace Учёт_Технических_Ресурсов.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginPageVM();
        }
    }
}
