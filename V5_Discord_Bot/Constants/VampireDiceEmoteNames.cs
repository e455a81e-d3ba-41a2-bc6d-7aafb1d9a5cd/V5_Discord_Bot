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