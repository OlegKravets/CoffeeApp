using CoffeeApp.Models;
using Newtonsoft.Json;

namespace CoffeeApp.Services
{
    public class CoffeeService
    {
        public CoffeeService()
        {
        }

        public List<Coffee> CoffeeList { get; set; } = new List<Coffee>();

        public async Task<IEnumerable<Coffee>> GetCoffees()
        {
            if (!CoffeeList.Any())
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync();
                CoffeeList = JsonConvert.DeserializeObject<List<Coffee>>(json);
            }

            return CoffeeList;
        }
    }
}
