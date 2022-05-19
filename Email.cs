using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace MailJet.EmailService
{
    public static class Email
    {
        public static async Task SendAsync()
        {

            MailjetClient client = new(Environment.GetEnvironmentVariable("****************************1234"),
                    Environment.GetEnvironmentVariable("****************************abcd"))
                { };

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }.Property(Send.Messages, new JArray
            {
                new JObject
                {
                    {
                        "From",
                        new JObject
                        {
                            {"Email", "quadrate.lk@gmail.com"},
                            {"Name", "Mohamed Farook"}
                        }
                    },
                    {
                        "To",
                        new JArray
                        {
                            new JObject
                            {
                                {
                                    "Email",
                                    "quadrate.lk@gmail.com"
                                },
                                {
                                    "Name",
                                    "Mohamed Farook"
                                }
                            }
                        }
                    },
                    {
                        "Subject",
                        "Greetings from Mailjet."
                    },
                    {
                        "TextPart",
                        "My first Mailjet email"
                    },
                    {
                        "HTMLPart",
                        "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
                    },
                    {
                        "CustomID",
                        "AppGettingStartedTest"
                    }
                }
            });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Total: {response.GetTotal()}, Count: {response.GetCount()}\n");
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine($"StatusCode: {response.StatusCode}\n");
                Console.WriteLine($"ErrorInfo: {response.GetErrorInfo()}\n");
                Console.WriteLine(response.GetData());
                Console.WriteLine($"ErrorMessage: {response.GetErrorMessage()}\n");
            }
        }
    }
}
