using System.Collections.Generic;

namespace V5_Discord_Bot.Constants
{
    public static class VampireDiceEmoteNames
    {
        public const string NormalSuccess = "normalsuccess";
        public const string NormalCrit = "normalcrit";
        public const string NormalFail = "normalfail";
        public const string RedSuccess = "redsuccess";
        public const string RedCrit = "redcrit";
        public const string RedFail = "redfail";
        public const string BestialFail = "bestialfail";

        public static List<string> EmoteNames = new List<string> { NormalSuccess, NormalCrit, NormalFail, RedSuccess, RedCrit, RedFail, BestialFail };
    }
}