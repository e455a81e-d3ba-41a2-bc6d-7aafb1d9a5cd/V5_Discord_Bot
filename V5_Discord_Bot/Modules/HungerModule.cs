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
using System.Threading.Tasks;
using V5_Discord_Bot.Services;

namespace V5_Discord_Bot.Modules
{
    public class HungerModule : ModuleBase<SocketCommandContext>

    {
        private readonly HungerService _hungerService;

        public HungerModule(HungerService hungerService)
        {
            _hungerService = hungerService;
        }

        [Command("gethunger")]
        public Task GetHunger()
        {
            var hunger = _hungerService.GetHunger(Context.User.Id);

            var embed = new EmbedBuilder()
                .WithColor(Color.DarkRed)
                .WithTitle($"Hunger")
                .WithDescription($"<@!{Context.User.Id}> Your hunger is **{hunger}**.")
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
                .WithDescription($"<@!{Context.User.Id}> Your hunger is now **{hunger}**.")
                .Build();
            return ReplyAsync(embed: embed);
        }

        [Command("gainhunger")]
        [Alias("addhunger")]
        public Task GainHunger()
        {
            var (hunger, hungerFrenzy) = _hungerService.IncrementHunger(Context.User.Id);
            var embedBuilder = new EmbedBuilder()
                .WithColor(Color.DarkRed)
                .WithTitle($"Gained Hunger");

            if (!hungerFrenzy)
            {
                var embed = embedBuilder
                    .WithDescription($"<@!{Context.User.Id}> Your hunger is now **{hunger}**.")
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
    }
}