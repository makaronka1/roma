using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

User roma = new User("cn",65);
User dima = new User("cv",31);
User clown = new User("cs",12);
User[] users = { roma, dima, clown };  
string json = JsonSerializer.Serialize(users);
var user2 = JsonSerializer.Deserialize<List<User>>(json);


var app = builder.Build();

app.MapGet("/jopa", () => { return users; });
app.MapPost("/popa", async(User user) => 
{
    User[] result = users.Append(user);
    users = result;
    return result;
  
});

app.MapPost("/dopa", async(User user) =>
{

    User[] result = users.Append(user);
    int id = user.id;
    for (int i=0;i<users.Length;i++)
    if(id == users[i].id)
    {
        id=i;
    }
    User[] newUsers = new User[users.Length - 1];
    for (int i = 0; i < id; i++)
    {
        newUsers[i] = users[i];
    }

    for (int i = id + 1; i < users.Length; i++)
        newUsers[i - 1] = users[i];

    users = newUsers;

});

app.MapPost("/flopa", async (User user) =>
{

    User[] result = users.Append(user);
    int id = user.id;
    string newName = user.name;
    for (int i = 0; i < users.Length; i++)
        if (id == users[i].id)
        {
            users[i].name=newName;
        }
        
   
});


app.Run();
    
class User
{
    public string name { get; set; }
    public int id { get; set; }
    public User(string name, int id)
    {
        this.id = id;
        this.name = name;
    }

}


public static class Extensions
{
    public static T[] Append<T>(this T[] array, T item)
    {
        if (array == null)
        {
            return new T[] { item };
        }
        T[] result = new T[array.Length + 1];
        array.CopyTo(result, 0);
        result[array.Length] = item;
        return result;
    }

   
}