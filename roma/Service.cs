using System.Text.Json;
namespace MainService
{

    public class Service
    {
        public string Pidor(object mass)
        {
            return JsonSerializer.Serialize(mass);
        }

        public string message()
        {
            return JsonSerializer.Serialize("error");
        }
    }

}
