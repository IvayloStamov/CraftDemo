using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CraftDemo.Core.Github
{
    public static class GithubCaller
    {
        public static async Task CallGithubUserByUsernameAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}";

            var token = "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";

            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/vnd.github+json");
            msg.Headers.Add("Authorization", $"Bearer {token}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }

        public static async Task GetOctocat()
        {
            var url = $"https://api.github.com/octocat";

            var token = "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";

            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/vnd.github+json");
            msg.Headers.Add("Authorization", "Bearer ${{ secrets.GITHUB_TOKEN }}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }
    }


}



