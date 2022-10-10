using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeniyIdiot.Common
{
    public class UserResultStorage
    {
        private static readonly string Path = "userResults.json";
        public static void Append(User user)
        {
            var usersResults = GetAll();
            usersResults.Add(user);
            Save(usersResults);
        }

        public static List<User> GetAll()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<User>();
            }
            var fileData = FileProvider.GetValue(Path);
            var userResults = JsonConvert.DeserializeObject<List<User>>(fileData);
            return userResults;
        }

        static void Save(List<User> usersResults)
        {
            var jsonData = JsonConvert.SerializeObject(usersResults, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }
    }
}