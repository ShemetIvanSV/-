using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model.Users
{
    class User : INotifyPropertyChanged
    {
        private string login;
        private string password;

        public string Login
        {
            get => login;
            set
            {
                OnPropertyChanged("Login");
                login = value;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                OnPropertyChanged("Password");
                password = value;
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
