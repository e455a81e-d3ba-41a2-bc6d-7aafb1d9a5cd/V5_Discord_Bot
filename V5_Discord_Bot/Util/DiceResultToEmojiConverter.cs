using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using V5_Discord_Bot.Constants;

namespace V5_Discord_Bot.Util
{
    public class DiceResultToEmojiConverter
    {

        public DiceResultToEmojiConverter()
        {
        }

        public ICollection<string?> ConvertNormalDice(ICollection<int> diceResult, Dictionary<string, GuildEmote?>? emotes)
        {
            return diceResult.Select(result =>
            {
                if (result == 10)
                {
                    return emotes[VampireDiceEmoteNames.NormalCrit]?.ToString();
                }
                else if (result >= 6)
                {
                    return emotes[VampireDiceEmoteNames.NormalSuccess]?.ToString();
                }
                else
                {
                    return emotes[VampireDiceEmoteNames.NormalFail]?.ToString();
                }
            }).ToList();
        }

        public ICollection<string?> ConvertHungerDice(ICollection<int> diceResult, Dictionary<string, GuildEmote?>? emotes)
        {
            return diceResult.Select(result =>
            {
                if (result == 10)
                {
                    return emotes[VampireDiceEmoteNames.RedCrit]?.ToString();
                }
                else if (result >= 6)
                {
                    return emotes[VampireDiceEmoteNames.RedSuccess]?.ToString();
                }
                else if (result == 1)
                {
                    return emotes[VampireDiceEmoteNames.BestialFail]?.ToString();
                }
                else
                {
                    return emotes[VampireDiceEmoteNames.RedFail]?.ToString();
                }
            }).ToList();
        }
    }
}