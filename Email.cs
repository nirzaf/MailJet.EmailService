using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace MailJet.EmailService
{
    public static class Email
    {
        //private static IConfiguration configurations { get; set; }
        
        //private static readonly string ApiKey = configurations.GetSection("Mailjet").GetSection("ApiKey").Value;
        //private static readonly string ApiSecret = configurations.GetSection("Mailjet").GetSection("ApiSecret").Value;

        public static async Task SendAsync()
        {
            MailjetClient client = new("c", "f");

            MailjetRequest request = new MailjetRequest
            {
                Resource = TemplateDetailcontent.Resource,
                ResourceId = ResourceId.Numeric(3945925)
            }.Property(
                Send.Messages, new JArray
                {
                    new JObject
                    {
                        {
                        "From", 
                        new JObject
                        {
                            {"Email", "quadrate.lk@gmail.com"},
                            {"Name", "Quadrate Tech Solutions"}
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
                                    "mfmfazrin1986@gmail.com"
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
