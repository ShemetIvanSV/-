using System;
using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.Users;

namespace Учёт_Технических_Ресурсов.Model
{
    class UsersInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<User>
            {
                new User{Login="Admin"},
                new User{Login="Сотрудник"}
            };
            users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();
        }
    }
}
