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

namespace V5_Discord_Bot.Services
{
    public class HungerService
    {
        private Dictionary<ulong, int> _hungerCache;

        public HungerService()
        {
            _hungerCache = new Dictionary<ulong, int>();
        }

        public void SetHunger(ulong userId, int hunger)
        {
            _hungerCache[userId] = hunger;
        }

        public int GetHunger(ulong userId)
        {
            if (_hungerCache.TryGetValue(userId, out var hunger))
                return hunger;

            //Default to 0 if no hunger set;
            hunger = 0;
            SetHunger(userId, hunger);
            return hunger;
        }

        public (int hunger, bool hungerFrenzy) IncrementHunger(ulong userId)
        {
            if (!_hungerCache.TryGetValue(userId, out var hunger))
                hunger = 0;

            if (hunger >= 5)
            {
                return (hunger, true);
            }

            hunger++;
            SetHunger(userId, hunger);
            return (hunger, false);
        }
    }
}