using System.Text;
using System.Text.Json;

namespace CraftDemo.Core.Freshdesk
{
    public class FreshdeskApi
    {
        //static string token = "gylgOGBRgJmQAtgeoWG8";
        //static string subdomain = "johnsmithandco";
        private readonly string _token;
        private readonly string _subdomain;

        public FreshdeskApi(string token, string subdomain)
        {
            _token = token;
            _subdomain = subdomain;
        }

        public async Task<string> GetAllContactsJson()
        {
            var url = $"https://{_subdomain}.freshdesk.com/api/v2/contacts";

            var encodedToken = Base64Encode(_token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<FreshdeskSearchModel> GetContactByName(string username)
        {
            var url = $"https://{_subdomain}.freshdesk.com/api/v2/contacts/autocomplete?term={username}";

            var encodedToken = Base64Encode(_token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();
            FreshdeskSearchModel[] model = JsonSerializer.Deserialize<FreshdeskSearchModel[]>(content);

            return model.FirstOrDefault();
        }

        public async Task<string> GetAccountInformationJson()
        {
            var url = $"https://{_subdomain}.freshdesk.com/api/v2/account";

            var encodedToken = Base64Encode(_token);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("Authorization", $"Bearer {encodedToken}");
            var result = await client.SendAsync(msg);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> CreateNewContact(FreshdeskContact newContact)
        {
            using var client = new HttpClient();
            var endpoint = new Uri($"https://{_subdomain}.freshdesk.com/api/v2/contacts");

            var encodedToken = Base64Encode(_token);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {encodedToken}");
            var newContactJson = JsonSerializer.Serialize(newContact);
            var payload = new StringContent(newContactJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(endpoint, payload);
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdateContact(FreshdeskContact newContact, long id)
        {
            using var client = new HttpClient();
            var endpoint = new Uri($"https://{_subdomain}.freshdesk.com/api/v2/contacts/{id}");

            var encodedToken = Base64Encode(_token);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {encodedToken}");
            var newContactJson = JsonSerializer.Serialize(newContact);
            var payload = new StringContent(newContactJson, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(endpoint, payload);
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
