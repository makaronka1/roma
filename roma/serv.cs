using System.Text.Json;

namespace AllService
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public User(string Name, string Surname)
        {
            this.Surname = Surname;
            this.Name = Name;
        }
    }
    public class MService
    {
       

        public List<User> users = new List<User>
        {
            new User("roman", "kozlov"),
            new User("dima", "skryabin"),
            new User("clown", "pidor"),
        };

        public string addUser(User newUser)
        {
            if ((newUser.Name != "") && (newUser.Surname != ""))
            {
                foreach (User user in users)
                {
                    if (user.Surname == newUser.Surname)
                    {
                        return "Ошибка,фамилия повторяется";
                    }
                }
                users.Add(newUser);
                return "Пользователь добавлен";
            }
            return "не все данные введены";
        }

        public string deleteUser (User deleteUser)
        {
            foreach (User user in users)
            {
                
                if ((user.Name == deleteUser.Name) && (user.Surname == deleteUser.Surname))
                {
                    users.Remove(user);
                    return "Пользователь удален";
                }
            }
            return "Пользователь не найдей";
        }

        public string editUser(User editUser)
        {
            foreach (User user in users)
            {
                if (user.Surname == editUser.Surname)
                {
                    users.Remove(user);
                    users.Add(editUser);
                    return "Пользователь изменен";
                }
            }
            return "Пользователь не найден";
        }

        public List<User> allUsers()
        {
            return users;
        }

        public string serializeObject(object obj)
        {
            string json = JsonSerializer.Serialize(obj);
            return json;
        } 
    }
}

