using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.DialogService;
using Учёт_Технических_Ресурсов.Model.Users;
using Учёт_Технических_Ресурсов.Views;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class LoginWindowVM : BaseViewModel
    {
        private ICommand validationCommand;
        private User currentUser;

        public LoginWindowVM()
        {
            CurrentUser = new User();
            UsersReturn();
        }

        public ObservableCollection<User> Users { get; set; }

        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged();

            }
        }

        public string CurrentLogin
        {
            get { return CurrentUser.Login; }
            set
            {
                CurrentUser.Login = value;
                OnPropertyChanged();
            }
        }

        public ICommand ValidationCommand
        { 
            get
            {
                return validationCommand ??
                    (validationCommand = new RelayCommand(obj =>
                    {
                        CurrentUser.Login = CurrentLogin;
                        if (UserValidation(CurrentUser))
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Application.Current.MainWindow.Close();
                            return;
                        }
                        MessageBox.Show("Неверное имя пользователя или пароль");
                    }));
            }
        }

        private void UsersReturn()
        {
            using (var userDb = new UserContext())
            {
                Users = new ObservableCollection<User>();
                foreach (var user in userDb.Users)
                {
                    Users.Add(user);
                }
            };
        }

        private bool UserValidation(User user)
        {
            bool isValid = false;

            if (user.Password == "")
                user.Password = null;

            foreach (var userDb in Users)
            {
                if (user.Login == userDb.Login && user.Password == userDb.Password)
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}
