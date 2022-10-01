using CraftDemo.Core.Github;
using Newtonsoft.Json;

namespace CraftDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Please, enter one of the following commands");
            string message = ("1 - Call Github \n2- Call Octocat\n3 - Call FreshDesk\n4 - End the program");
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (true)
            {
                if(input == "1")
                {
                    Console.WriteLine("Please, enter the Github username");
                    string username = Console.ReadLine();
                    GithubCaller.CallGithubUserByUsernameAsync(username);

                }
                else if(input == "2")
                {
                    GithubCaller.GetOctocat();
                }
                else if(input == "3")
                {

                }
                else if(input == "4")
                {
                    Console.WriteLine("The program will end shortly!");
                    break;
                }

                Console.WriteLine(message);
                input = Console.ReadLine();
            }
        }
    }
}