using CraftDemo.Core.Data.Models;
using Newtonsoft.Json;

namespace CraftDemo.Core.Github
{
    public static class GithubConverter
    {
        public static GithubUser ConvertRawDataIntoGithubUser(string json)
        {
            RawGithubInput rawGithubInput = JsonConvert.DeserializeObject<RawGithubInput>(json);
            GithubUser githubUser = new GithubUser
            {
                Username = rawGithubInput.login,
                Name = rawGithubInput.name,
                CreationDate = rawGithubInput.created_at
            };
            return githubUser;
        }
    }
}
