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
using System.Collections.Generic;
using System.Linq;
using V5_Discord_Bot.Constants;

namespace V5_Discord_Bot.Services
{
    public class GuildEmoteService
    {
        private Dictionary<ulong, Dictionary<string, GuildEmote?>> _guildEmoteCache;

        public GuildEmoteService()
        {
            _guildEmoteCache = new Dictionary<ulong, Dictionary<string, GuildEmote?>>();
        }

        public void CheckAndUpdateEmoteCache(SocketCommandContext context)
        {
            if (_guildEmoteCache.ContainsKey(context.Guild.Id)) return;

            UpdateEmoteCache(context.Guild);
        }

        public void UpdateEmoteCache(SocketGuild guild)
        {
            var emotes = guild.Emotes.ToList();

            var emoteDictionary = new Dictionary<string, GuildEmote?>();
            foreach (var emoteName in VampireDiceEmoteNames.EmoteNames)
            {
                var emote = emotes.Find(t => t.Name.Contains(emoteName));
                emoteDictionary[emoteName] = emote;
            }
            _guildEmoteCache[guild.Id] = emoteDictionary;
        }

        public Dictionary<string, GuildEmote?>? GetEmotesForGuild(ulong guildId)
        {
            if (!_guildEmoteCache.TryGetValue(guildId, out var emotes))
                return null;
            return emotes;
        }
    }
}