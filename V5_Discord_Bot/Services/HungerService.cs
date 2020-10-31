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