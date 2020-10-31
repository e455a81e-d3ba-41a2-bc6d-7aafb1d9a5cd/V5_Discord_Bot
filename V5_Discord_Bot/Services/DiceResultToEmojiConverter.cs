using Discord;
using System.Collections.Generic;
using System.Linq;
using V5_Discord_Bot.Constants;

namespace V5_Discord_Bot.Services
{
    public class DiceResultToEmojiConverter
    {
        public List<string> ConvertNormalDice(List<int> diceResult, Dictionary<string, GuildEmote?>? emotes)
        {
            if (emotes == null)
            {
                return diceResult.Select(t => t.ToString()).ToList();
            }

            return diceResult.Select(result =>
            {
                if (result == 10)
                {
                    return emotes[VampireDiceEmoteNames.NormalCrit]?.ToString() ?? result.ToString();
                }
                else if (result >= 6)
                {
                    return emotes[VampireDiceEmoteNames.NormalSuccess]?.ToString() ?? result.ToString();
                }
                else
                {
                    return emotes[VampireDiceEmoteNames.NormalFail]?.ToString() ?? result.ToString();
                }
            }).ToList();
        }

        public List<string> ConvertHungerDice(List<int> diceResult, Dictionary<string, GuildEmote?>? emotes)
        {
            if (emotes == null)
            {
                return diceResult.Select(t => t.ToString()).ToList();
            }

            return diceResult.Select(result =>
            {
                if (result == 10)
                {
                    return emotes[VampireDiceEmoteNames.RedCrit]?.ToString() ?? result.ToString();
                }
                else if (result >= 6)
                {
                    return emotes[VampireDiceEmoteNames.RedSuccess]?.ToString() ?? result.ToString();
                }
                else if (result == 1)
                {
                    return emotes[VampireDiceEmoteNames.BestialFail]?.ToString() ?? result.ToString();
                }
                else
                {
                    return emotes[VampireDiceEmoteNames.RedFail]?.ToString() ?? result.ToString();
                }
            }).ToList();
        }
    }
}