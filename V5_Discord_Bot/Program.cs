using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using V5_Discord_Bot.Services;

namespace V5_Discord_Bot
{
    class Program
    {

        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            using var services = ConfigureServices();

            var client = services.GetRequiredService<DiscordSocketClient>();
            client.Log += Log;
            services.GetRequiredService<CommandService>().Log += Log;

            var token = Environment.GetEnvironmentVariable("DiscordToken", EnvironmentVariableTarget.Machine);
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<CommandService>()
                .AddSingleton<DiceRollerService>()
                .AddSingleton<HungerService>()
                .AddSingleton<DiceResultToEmojiConverter>()
                .AddSingleton<GuildEmoteService>()
                .BuildServiceProvider();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
