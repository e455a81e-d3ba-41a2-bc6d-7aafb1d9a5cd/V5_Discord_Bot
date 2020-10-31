using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V5_Discord_Bot.Services;
using V5_Discord_Bot.Util;

namespace V5_Discord_Bot.Modules
{
    public class DiceRollModule : ModuleBase<SocketCommandContext>
    {
        private readonly DiceRollerService _diceRollerService;
        private readonly HungerService _hungerService;
        private readonly DiceResultToEmojiConverter _emojiConverter;
        private readonly GuildEmoteService _guildEmoteService;

        public DiceRollModule(DiceRollerService diceRollerService, HungerService hungerService, DiceResultToEmojiConverter emojiConverter, GuildEmoteService guildEmoteService)
        {
            _diceRollerService = diceRollerService;
            _hungerService = hungerService;
            _emojiConverter = emojiConverter;
            _guildEmoteService = guildEmoteService;
        }

        [Command("roll")]
        public Task Roll(int amount)
        {
            if (amount <= 0)
            {
                return ReplyAsync("You must at least roll a single die.");
            }
            else if (amount > 100)
            {
                return ReplyAsync("Thats to much work!");
            }

            var result = _diceRollerService.Roll(Context.User.Id, amount);

            var fields = new List<EmbedFieldBuilder>();

            var emotes = _guildEmoteService.GetEmotesForGuild(Context.Guild.Id);
            if (result.NormalDice.Count > 0)
                fields.Add(
                new EmbedFieldBuilder()
                    .WithName("Normal Die")
                    .WithValue(string.Join(" ", _emojiConverter.ConvertNormalDice(result.NormalDice, emotes)))
            );

            if (result.HungerDice.Count > 0)
                fields.Add(
                new EmbedFieldBuilder()
                    .WithName("Hunger Die")
                    .WithValue(string.Join(" ", _emojiConverter.ConvertHungerDice(result.HungerDice, emotes)))
                );

            var embed = new EmbedBuilder()
                .WithColor(Color.DarkRed)
                .WithTitle($"Roll Result")
                .WithDescription($"<@!{Context.User.Id}>")
                .WithFields(fields)
                .Build();
            return ReplyAsync(embed: embed);
        }

        [Command("sethunger")]
        public Task SetHunger(int hunger)
        {
            if (hunger < 0 || hunger > 5)
                return ReplyAsync("Hunger must be between 0 and 5");

            _hungerService.SetHunger(Context.User.Id, hunger);

            var embed = new EmbedBuilder()
                .WithColor(Color.DarkRed)
                .WithTitle($"Hunger")
                .WithDescription($"<@!{Context.User.Id}> hunger is now **{hunger}**.")
                .Build();
            return ReplyAsync(embed: embed);
        }

        [Command("gainhunger")]
        public Task GainHunger()
        {
            var (hunger, hungerFrenzy) = _hungerService.IncrementHunger(Context.User.Id);
            var embedBuilder = new EmbedBuilder()
                .WithColor(Color.DarkRed)
                .WithTitle($"Gained Hunger");

            if (!hungerFrenzy)
            {
                var embed = embedBuilder
                    .WithDescription($"<@!{Context.User.Id}> hunger is now **{hunger}**.")
                    .Build();
                return ReplyAsync(embed: embed);
            }
            else
            {
                var embed = embedBuilder
                    .WithDescription($"<@!{Context.User.Id}> falls under the control of the beast and is now frenzying.")
                    .Build();
                return ReplyAsync(embed: embed);
            }
        }

        [Command("rouse")]
        public Task Rouse()
        {
            var (success, hunger, hungerFrenzy) = _diceRollerService.Rouse(Context.User.Id);
            var embedBuilder = new EmbedBuilder()
                .WithColor(Color.DarkRed)
                .WithTitle($"Rouse");

            if (success)
            {
                var embed = embedBuilder
                    .WithDescription($"**Success** <@!{Context.User.Id}> hunger does not increase.")
                    .Build();
                return ReplyAsync(embed: embed);
            }
            else if (!hungerFrenzy)
            {
                var embed = embedBuilder
                    .WithDescription($"**Failure** <@!{Context.User.Id}> hunger is now **{hunger}**.")
                    .Build();
                return ReplyAsync(embed: embed);
            }
            else
            {
                var embed = embedBuilder
                    .WithDescription($"**Failure** <@!{Context.User.Id}> falls under the control of the beast and is now frenzying.")
                    .Build();
                return ReplyAsync(embed: embed);
            }
        }
    }
}