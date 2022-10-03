using CraftDemo.Core.Data;
using CraftDemo.Core.Freshdesk;
using CraftDemo.Core.Github;
using Newtonsoft.Json;

namespace CraftDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var context = new CraftDemoContext();
            //string githubToken = Console.ReadLine();
            //string freshdeskToken = Console.ReadLine();

            string message = ("Please, enter one of the following commands!" +
                "\n1 - Use the GithubCaller to get infromation about GithubUsers, add their " +
                "information in a database and create Freshdesk contacts using the said information." +
                "\n2 - Call Octocat" +
                "\n3 - Get information about your subdomain." +
                "\n4 - Update a Freshdesk contact" +
                "\n5 - End the program");
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (true)
            {
                if(input == "1")
                {
                    Console.WriteLine("Please, enter the Github username.");
                    string inputGithubUsername = Console.ReadLine();
                    var result = await GithubCaller.CallGithubUserByUsernameAsync(inputGithubUsername);
                    
                    var githubUser = GithubConverter.ConvertRawDataIntoGithubUser(result);
                    if(githubUser.Username == null)
                    {
                        Console.WriteLine("There is no Github user with such a username.");
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine(message);
                        input = Console.ReadLine();

                        continue;
                    }

                    var userToCheck = context.GithubUsers.FirstOrDefault(x => x.Username == inputGithubUsername);
                    if (userToCheck != null)
                    {
                        if(githubUser.Name == userToCheck.Name)
                        {
                            Console.WriteLine("Such a user already exists in the database.");
                        }
                        else
                        {
                            userToCheck.Name = githubUser.Name;
                        }
                    }
                    else
                    {
                        await context.GithubUsers.AddAsync(githubUser);
                        await context.SaveChangesAsync();
                        Console.WriteLine($"User {githubUser.Username} was successfully added to the database.");

                        Console.WriteLine("Would you like to create a new contact in Freshdesk based on the Github user?" +
                            " \n1 - Yes, please! \n2 - No, thank you!");
                        string inputAnswer = Console.ReadLine();
                        if (inputAnswer == "1")
                        {
                            //int githubUserId = githubUser.Id;
                            FreshdeskContact freshdeskContact = FreshdeskConverter.ConvertRawGithubInputIntoFreshdeskContact(result);
                            await FreshdeskCaller.CreateNewFreshdeskContact(freshdeskContact);
                            Console.WriteLine("The FreshDesk contact has been successfully created.");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if(input == "2")
                {
                    await GithubCaller.GetOctocat();
                }
                else if(input == "3")
                {
                    await FreshdeskCaller.CallFreshdeskSubdomain();
                }
                else if(input == "4")
                {
                    Console.WriteLine("Please, type in the current name of the contact, that you want to update");
                    string userName = Console.ReadLine();

                    var result = await FreshdeskCaller.CallFreshdeskContactByName(userName);
                    FreshdeskSearchModel[] freshdeskSearchModel = JsonConvert.DeserializeObject<FreshdeskSearchModel[]>(result);
                    long contactId = freshdeskSearchModel[0].id;
                    FreshdeskContact freshdeskContact = new FreshdeskContact();
                    Console.WriteLine("Please, enter the new name or reenter the current name of the contact, that will be updated:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please, enter the new email or reenter the current email of the contact, that will be updated:");
                    string email = Console.ReadLine();

                    freshdeskContact.name = name;
                    freshdeskContact.email = email;

                    await FreshdeskCaller.UpdateFreshdeskContact(freshdeskContact, contactId);
                    Console.WriteLine("The contact has been updated.");
                }
                else if(input == "5")
                {
                    Console.WriteLine("The program will end shortly.");
                    break;
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
        }
    }
}