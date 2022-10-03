
using System.Text.Json;

namespace CraftDemo.Core.Github
{
    public class GithubApi
    {
        private readonly string _token;

        public GithubApi(string token)
        {
            _token = token;
        }

        public async Task<GithubApiUser> GetUserByUsername(string username)
        {
            var url = $"https://api.github.com/users/{username}";

            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/vnd.github+json");
            msg.Headers.Add("Authorization", $"Bearer {_token}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();
            GithubApiUser user = JsonSerializer.Deserialize<GithubApiUser>(content);

            return user;
        }

        public async Task<string> GetOctocat()
        {
            var url = $"https://api.github.com/octocat";

            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/vnd.github+json");
            msg.Headers.Add("Authorization", $"Bearer {_token}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();

            return content;
        }
    }


}



