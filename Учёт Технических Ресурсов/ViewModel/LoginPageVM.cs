using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учёт_Технических_Ресурсов.Command;
using Учёт_Технических_Ресурсов.Model.Users;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class LoginPageVM : BaseViewModel
    {
        private ObservableCollection<User> Users { get; set; }
        private User User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        private BaseCommand validationCommand;
        public BaseCommand ValidationCommand
        {
            get
            {
                return validationCommand ??
                    (validationCommand = new BaseCommand(obj =>
                    {
                        User = new User()
                        {
                            Login = Login,
                            Password = Password
                        };
                        
                        if(Validation(User))
                        {
                            using (var userDb = new UserContext())
                            {
                                var users = userDb.Users;
                                users.Add(User);
                                userDb.SaveChanges();
                            };
                        }
                    }));
            }
        }

        public LoginPageVM()
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

        private bool Validation(User user)
        {
            bool isValid = false;
            foreach(var userDb in Users)
            {
                if(user.Login == userDb.Login && user.Password == userDb.Password)
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
