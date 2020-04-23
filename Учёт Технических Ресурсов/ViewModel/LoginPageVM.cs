using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.Command;
using Учёт_Технических_Ресурсов.Model.Users;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class LoginPageVM : BaseViewModel
    {
        private ObservableCollection<User> Users { get; set; }
        public User CurrentUser { get; set; } = new User();


        private ICommand validationCommand;
        public ICommand ValidationCommand
        {
            get
            {
                return validationCommand ??
                    (validationCommand = new RelayCommand(obj =>
                    {
                        if (UserValidation(CurrentUser))
                        {
                            //This is very very bad
                            NavigationService.Page1Moving();
                        }
                        else
                        {
                            //This is bad
                            MessageBox.Show("Неверное имя пользователя или пароль");
                        }

                    }));
            }
        }

        public LoginPageVM()
        {
            UsersReturn();
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
            foreach (var userDb in Users)
            {
                if (user.Login == userDb.Login && user.Password == userDb.Password)
                {
                    isValid = true;
                    break;
                }
                isValid = false;
            }
            return isValid;
        }
    }
}
