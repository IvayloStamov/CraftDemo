using Newtonsoft.Json;
using System.Text;

namespace CraftDemo.Core.Freshdesk
{
    public static class FreshdeskCaller
    {
        public static async Task CallAllFreshdeskContacts()
        {
            var url = $"https://johnsmithandco.freshdesk.com/api/v2/contacts";

            var token = "gylgOGBRgJmQAtgeoWG8";
            var encodedToken = Base64Encode(token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            msg.Headers.Add("User-Agent", "Awesome-Octocat-App");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }

        public static async Task Third()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://johnsmithandco.freshdesk.com/api/v2/contacts");
                var newContact = new FreshdeskContact
                {
                    name = "Name",
                    email = "email@email.com"
                };
                var token = "gylgOGBRgJmQAtgeoWG8";
                var encodedToken = Base64Encode(token);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {encodedToken}");
                var newContactJson = JsonConvert.SerializeObject(newContact);
                var payload = new StringContent(newContactJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result);
            }
        }

        public static async Task SecondFreshdeskContactAsyncCaller()
        {
            using (var client = new HttpClient())
            {
                var url = $"https://johnsmithandco.freshdesk.com/api/v2/contacts";

                var token = "gylgOGBRgJmQAtgeoWG8";
                var encodedToken = Base64Encode(token);

                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {encodedToken}");
                //client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");
                var result = await client.SendAsync(msg);
                var content = await result.Content.ReadAsStringAsync();

                Console.WriteLine(content);
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
