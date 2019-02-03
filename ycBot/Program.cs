using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ycBot
{
    public class Program
    {
        //prefix for bot commands
        string comPrefix = "!";

        public static void Main(string[] args)
             => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            //create a new discord REST client
            var client = new DiscordSocketClient();
            //set log
            client.Log += Log;

            client.MessageReceived += MessageReceived;

            //login and start client
            string token = "NTQxNDEzMjI0OTgxOTg3MzM4.DzfMkQ.V0ehYWb_khgH5citXUUga6i-nRY";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            //we don't want this task to be used again after launch so pause it indefinitley
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)    //needed to handle logging events, will log to a file later, this only outputs to the consle
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == comPrefix + "yaoi")
            {
                await message.Channel.SendMessageAsync("YC!");
            }
        }
    }
}
