using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.DialogService;
using Учёт_Технических_Ресурсов.Model.Users;
using Учёт_Технических_Ресурсов.Views;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class RegistrationVM : BaseViewModel
    {
        private string login;
        private string password;
        private ICommand registrationCommand;
        private ICommand removeCommand;
        private ICommand backCommand;
        private User selectedUser;
        private Action Close;
        public RegistrationVM(Action close)
        {
            Close = close;
            SelectedUser = new User();
            Users = new ObservableCollection<User>();
            UsersReturn();
        }

        public string Login
        {
            get => login;
            set
            {
                using (UserContext userContext = new UserContext())
                {
                    var users = userContext.Users;
                    foreach (var user in users)
                    {
                        if (user.Login != value)
                        {
                            login = value;
                            OnPropertyChanged();
                        }
                        else
                        {
                            DocumentDialogService documentDialogService = new DocumentDialogService();
                            documentDialogService.ShowMessage("Пользователь с таким логином уже существует");
                        }
                    }
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> Users { get; set; }

        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        protected void UsersReturn()
        {
            Users.Clear();
            using (var userContext = new UserContext())
            {
               var users = userContext.Users;
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
        }

        public void UserRemove()
        {
            try
            {
                using (var userContext = new UserContext())
                {
                    var dataContextUsers = userContext.Users;
                    dataContextUsers.Attach(SelectedUser);
                    dataContextUsers.Remove(SelectedUser);
                    userContext.SaveChanges();
                }
                UsersReturn();
            }

            catch (DbUpdateConcurrencyException)
            {
                DocumentDialogService documentDialogService = new DocumentDialogService();
                documentDialogService.ShowMessage("Элемент не найден");
            }
        }

        public ICommand RegistrationCommand => registrationCommand ??
                                               (registrationCommand = new RelayCommand(obj =>
                                               {
                                                   var User = new User()
                                                   {
                                                       Login = this.Login,
                                                       Password = this.Password
                                                   };
                                                   try
                                                   {
                                                       using (UserContext userContext = new UserContext())
                                                       {
                                                           userContext.Users.Add(User);
                                                           userContext.SaveChanges();
                                                           UsersReturn();
                                                       }
                                                   }
                                                   catch (Exception e)
                                                   {
                                                       
                                                   }
                                               }));

        public ICommand RemoveCommand => removeCommand ??
                                              (removeCommand = new RelayCommand(obj =>
                                              {
                                                  UserRemove();
                                              }));

        public ICommand BackCommand => backCommand ??
                                              (backCommand = new RelayCommand(obj =>
                                              {
                                                  Login login = new Login();
                                                  login.Show();
                                                  Close();
                                              }));
    }
}
