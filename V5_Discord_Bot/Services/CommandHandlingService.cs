using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace V5_Discord_Bot.Services
{
    public class CommandHandlingService
    {
        private readonly CommandService _commandService;
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly GuildEmoteService _guildEmoteService;

        public CommandHandlingService(CommandService commandService, DiscordSocketClient discordSocketClient, IServiceProvider serviceProvider, GuildEmoteService guildEmoteService)
        {
            _commandService = commandService;
            _discordSocketClient = discordSocketClient;
            _serviceProvider = serviceProvider;
            _guildEmoteService = guildEmoteService;
            _discordSocketClient.MessageReceived += MessageReceivedAsync;
            _commandService.CommandExecuted += CommandExecutedAsync;
        }

        public async Task InitializeAsync()
        {
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
        }

        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            if (!(rawMessage is SocketUserMessage message)) return;
            if (message.Source != MessageSource.User) return;

            var argPos = 0;
            if (!message.HasCharPrefix('!', ref argPos)) return;

            var context = new SocketCommandContext(_discordSocketClient, message);
            _guildEmoteService.CheckAndUpdateEmoteCache(context);
            await _commandService.ExecuteAsync(context, argPos, _serviceProvider);
        }

        private async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified) return;
            if (result.IsSuccess) return;
            await context.Channel.SendMessageAsync($"error: {result}");
        }
    }
}