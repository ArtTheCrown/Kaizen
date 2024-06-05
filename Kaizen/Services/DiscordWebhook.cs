using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Kaizen.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Kaizen.Services
{
    public static class WebHook
    {
        public static async Task SendEmbedAsync(string webhookUrl, User user, string status, string val)
        {
            using (HttpClient client = new HttpClient())
            {
                var fields = new List<Field>();
                foreach (var task in user.ActiveTasks)
                {
                    string name = "Error Code 20, WebHook.";
                    if (task.Completed == "Completed") name = "Completed :white_check_mark:";
                    else if (task.Completed == "Incomplete") name = "Incomplete :x:";
                    else if (task.Completed == "Failed") name = "Failed :x:";
                    fields.Add(new Field
                    {
                        Name = name,
                        Value = task.Title
                    });
                }

                string desc = $"";
                string title = "";
                if (status == "Failed")
                {
                    desc = $"**{user.Username} has failed a task :x: ** ```{val}```";
                    title = "Failure :x:";
                }
                else if (status == "Completed")
                {
                    desc = $"**{user.Username} has completed a task :white_check_mark: ** ```{val}```";
                    title = "Task Completed ";
                }
                else if (status == "Update")
                {
                    desc = $"**Momentary Update for {user.Username}**";
                    title = "Momentary Update";
                }
                else if (status == "Added")
                {
                    desc = $"**{user.Username} has added a new Task** ```{val}```";
                    title = "Task Added :pencil:";
                }

                var payload = new WebhookPayload
                {
                    Content = "",
                    Embeds = new List<Embed>
                    {
                        new Embed
                        {
                            Title =  title,
                            Description = desc,
                            Color = status == "Failed"? 16711680 : 720640,
                            Footer = new Footer
                            {
                                Text = "================================================================"
                            },
                            Image = new Image
                            {
                                Url = "https://cdn.discordapp.com/attachments/900450133446107256/1233772980262146089/c8340d09-fdcd-4d88-a6c4-bf20f5d47040.jpg?ex=6659d1a0&is=66588020&hm=9924e1e10e5f408f092df9213f647d283a55d247cee54fa411c2ada52185bc45&"
                            }
                       },
                         new Embed
                        {
                            Title = user.Username,
                            Description = $"**Streak : ** `{user.Streak}`\n**Habits Inculcated : ** `{user.HabitsInculcated.Count}`\n**Failed attempts : ** `{user.FailedAttempts}` \n\n======================================================",
                            Color = 5814783,
                            Fields = fields
                        }
                    },
                    Username = $"༒༺ 改善 ༻༒",
                    AvatarUrl = "https://cdn.discordapp.com/attachments/900450133446107256/1233772980262146089/c8340d09-fdcd-4d88-a6c4-bf20f5d47040.jpg?ex=6659d1a0&is=66588020&hm=9924e1e10e5f408f092df9213f647d283a55d247cee54fa411c2ada52185bc45&",
                    Attachments = new List<object>()
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(webhookUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error sending message: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine("Message sent successfully");
                }
            }
        }
    }

    public class Footer
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Field
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Embed
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }

        [JsonProperty("footer")]
        public Footer Footer { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
    }

    public class WebhookPayload
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }
    }

}
