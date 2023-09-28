using CoffeeApp.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace CoffeeApp.Services
{
    public class LoginService
    {
        public LoginService()
        {
        }

        public async Task<bool> Login(string userName, string password)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("users.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);

            using var hmac = new HMACSHA512();
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            User currentUser = users.FirstOrDefault(u => u.UserName == userName);

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != currentUser.Password[i])
                {
                    return false;
                }
            }

            return true;
        }

        public async Task Register(string userName, string password)
        {
            List<User> users = null;
            using var stream = await FileSystem.OpenAppPackageFileAsync("users.json");
            using var reader = new StreamReader(stream);

            var json = await reader.ReadToEndAsync();
            users = JsonConvert.DeserializeObject<List<User>>(json);

            int lastId = users is not null && users.Any()
                ? users.Max(u => u.Id)
                : 0;

            using var hmac = new HMACSHA512();
            users.Add(
                new User()
                {
                    Id = lastId + 1,
                    UserName = userName,
                    Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
                });

            File.WriteAllText("users.json", JsonConvert.SerializeObject(users));
        }
    }
}
