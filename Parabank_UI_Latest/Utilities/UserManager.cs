using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Models;

namespace Parabank_UI_Latest.Utilities
{
    public static class UserManager
    {
        private static string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string userDataPath = Path.Combine(basePath, "TestData/users.json");

        public static User CreateNewUser()
        {
            var user = new User
            {
                FirstName = "Auto",
                LastName = "Test",
                Address = "Lane no 1",
                City = "Pune",
                State = "NA",
                ZipCode = "411000",
                Phone = GeneratePhone(),
                SSN = GenerateSSN(),
                Username = GenerateUsername(),
                Password = "Test@123"
            };

            SaveUser(user);
            return user;
        }


        private static void SaveUser(User user)
        {
            var users = TestDataReader.Read<User>(userDataPath);
            Console.WriteLine("UserdataPath:"+ userDataPath);
            users.Add(user);
            TestDataReader.Write(userDataPath, users);
        }


        // --------------------------
        // Helper methods
        // --------------------------

        private static string GenerateUsername()
        {
            return "Test_user_" + BasePage.RandomString(3);
        }

        private static string GeneratePhone()
        {
            return "9" + new Random().Next(100000000, 999999999);
        }

        private static string GenerateSSN()
        {
            return new Random().Next(1000, 9999).ToString();
        }

    }
}