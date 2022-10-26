using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AllService;

MService mservice = new MService();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/allusers", () =>
{
    List<User> users = mservice.allUsers();
    return mservice.serializeObject(users);
});

app.MapPost("/delete", (User user) =>
{
    return mservice.deleteUser(user);
});

app.MapPost("/edit", (User user) =>
 {
     return mservice.editUser(user);
 });

app.MapPost("/newusers", (User user) =>
 {
     return mservice.addUser(user);
 });

app.Run();