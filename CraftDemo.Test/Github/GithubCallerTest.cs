using CraftDemo.Core.Github;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CraftDemo.Test.Github
{
    public class GithubCallerTest
    {
        [Fact]
        public async Task CallGithubUserByUsernameAsync_ShouldReturnValidJsonSting()
        {
            //Arrange
            var username = "c9s";

            //Act

            var result = await GithubCaller.CallGithubUserByUsernameAsync(username);

            //Assert
           
            var isJson = IsValidJson(result);
            Assert.True(isJson);
        }

        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || 
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
