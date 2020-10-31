using System;
using System.Collections.Generic;

namespace V5_Discord_Bot.Model
{
    public class RollResult
    {
        private List<int>? _normalDice;
        private List<int>? _hungerDice;

        public List<int> NormalDice
        {
            get => _normalDice ?? throw new InvalidOperationException("Uninitialized property: " + nameof(NormalDice));
            set => _normalDice = value;
        }

        public List<int> HungerDice
        {
            get => _hungerDice ?? throw new InvalidOperationException("Uninitialized property: " + nameof(HungerDice));
            set => _hungerDice = value;
        }
    }
}