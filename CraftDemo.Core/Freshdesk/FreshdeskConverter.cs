using CraftDemo.Core.Github;
using Newtonsoft.Json;

namespace CraftDemo.Core.Freshdesk
{
    public static class FreshdeskConverter
    {
        public static FreshdeskContact ConvertRawGithubInputIntoFreshdeskContact(string json)
        {
            RawGithubInput rawGithubInput = JsonConvert.DeserializeObject<RawGithubInput>(json);
           
            var contact = new FreshdeskContact();

            contact.email = rawGithubInput.email;
            contact.name = rawGithubInput.login;
            contact.unique_external_id = rawGithubInput.id;
            return contact;
        }
    }
}
