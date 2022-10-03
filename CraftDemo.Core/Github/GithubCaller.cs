namespace CraftDemo.Core.Github
{
    public static class GithubCaller
    {
        static string token = "";
        public static async Task<string> CallGithubUserByUsernameAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}";

            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/vnd.github+json");
            msg.Headers.Add("Authorization", $"Bearer {token}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();

            return content;
        }

        public static async Task GetOctocat()
        {
            var url = $"https://api.github.com/octocat";

            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/vnd.github+json");
            msg.Headers.Add("Authorization", $"Bearer {token}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }
    }


}



