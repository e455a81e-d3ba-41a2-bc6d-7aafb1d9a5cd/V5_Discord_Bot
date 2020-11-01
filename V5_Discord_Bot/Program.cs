/*
* Copyright 2019 Leonhardt Schwarz
*
* Licensed under the EUPL, Version 1.2 only (the "Licence");
* You may not use this work except in compliance with the
Licence.
* You may obtain a copy of the Licence at:
*
* https://joinup.ec.europa.eu/software/page/eupl 5
*
* Unless required by applicable law or agreed to in
writing, software distributed under the Licence is
distributed on an "AS IS" basis,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
express or implied.
* See the Licence for the specific language governing
permissions and limitations under the Licence.
*/

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using V5_Discord_Bot.Exceptions;
using V5_Discord_Bot.Services;

namespace V5_Discord_Bot
{
    internal class Program
    {
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            using var services = ConfigureServices();

            var client = services.GetRequiredService<DiscordSocketClient>();
            client.Log += Log;
            services.GetRequiredService<CommandService>().Log += Log;

            var token = Environment.GetEnvironmentVariable("DiscordToken", EnvironmentVariableTarget.Machine);
            if (token == null)
            {
                throw new BotTokenException("The DiscordToken environment variable is missing or empty. The bot can not function without this token.");
            }
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