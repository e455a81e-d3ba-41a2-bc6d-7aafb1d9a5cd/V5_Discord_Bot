using Discord;
using Discord.Commands;
using System.Text;
using System.Threading.Tasks;
using V5_Discord_Bot.Services;

namespace V5_Discord_Bot.Modules
{
    public class BotModule : ModuleBase<SocketCommandContext>

    {
        private readonly GuildEmoteService _guildEmoteService;

        public BotModule(GuildEmoteService guildEmoteService)
        {
            _guildEmoteService = guildEmoteService;
        }

        [Command("verifyemotes")]
        [RequireUserPermission(GuildPermission.ManageEmojis)]
        public Task UpdateGuildEmotes()
        {
            _guildEmoteService.UpdateEmoteCache(Context.Guild);
            var emotes = _guildEmoteService.GetEmotesForGuild(Context.Guild.Id);
            if (emotes == null)
                return ReplyAsync("I was unable to update the emote cache.");

            var sb = new StringBuilder();
            sb.AppendLine("The following emotes where found:");
            foreach (var emote in emotes)
            {
                sb
                    .Append(":white_small_square:")
                    .Append(emote.Key)
                    .Append("\t→\t")
                    .AppendLine(emote.Value?.ToString() ?? ":x: **Not found!**");
            }
            return ReplyAsync(sb.ToString());
        }
    }
}