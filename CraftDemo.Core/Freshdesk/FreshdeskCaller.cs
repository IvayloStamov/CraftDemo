using Newtonsoft.Json;
using System.Text;

namespace CraftDemo.Core.Freshdesk
{
    public static class FreshdeskCaller
    {
        static string token = "gylgOGBRgJmQAtgeoWG8";
        static string subdomain = "johnsmithandco";
        public static async Task CallAllFreshdeskContacts()
        {
            var url = $"https://{subdomain}.freshdesk.com/api/v2/contacts";

            var encodedToken = Base64Encode(token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }

        public static async Task<string> CallFreshdeskContactByName(string username)
        {
            var url = $"https://{subdomain}.freshdesk.com/api/v2/contacts/autocomplete?term={username}";

            var encodedToken = Base64Encode(token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public static async Task CallFreshdeskSubdomain()
        {
            var url = $"https://{subdomain}.freshdesk.com/api/v2/account";

            //var token = "gylgOGBRgJmQAtgeoWG8";
            var encodedToken = Base64Encode(token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }

        public static async Task CreateNewFreshdeskContact(FreshdeskContact newContact)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://{subdomain}.freshdesk.com/api/v2/contacts");
                
                var encodedToken = Base64Encode(token);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {encodedToken}");
                var newContactJson = JsonConvert.SerializeObject(newContact);
                var payload = new StringContent(newContactJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task UpdateFreshdeskContact(FreshdeskContact newContact, long id)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://{subdomain}.freshdesk.com/api/v2/contacts/{id}");

                var encodedToken = Base64Encode(token);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {encodedToken}");
                var newContactJson = JsonConvert.SerializeObject(newContact);
                var payload = new StringContent(newContactJson, Encoding.UTF8, "application/json");
                var result = client.PutAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
