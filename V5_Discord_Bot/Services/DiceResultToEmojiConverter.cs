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