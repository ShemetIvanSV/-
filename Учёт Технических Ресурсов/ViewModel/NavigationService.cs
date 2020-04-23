using System.Windows.Controls;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.Command;
using Учёт_Технических_Ресурсов.Pages;
using Учёт_Технических_Ресурсов.View;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    static class NavigationService
    {
        private static Page login;
        private static Page page1;
        public static Page Page { get; set; }
        static NavigationService()
        {
            login = new Login();
            page1 = new Page1();
            Page = login;
        }
        public static void Page1Moving()
        {
            Page = page1;
        }
            
    }
}
