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
using System.Windows.Shapes;
using Учёт_Технических_Ресурсов.ViewModel;

namespace Учёт_Технических_Ресурсов.Views
{
    public delegate void CloseHandelr(); 
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Action close = new Action(this.Close);
            DataContext = new  LoginPageVM(close);
        }
    }
}
