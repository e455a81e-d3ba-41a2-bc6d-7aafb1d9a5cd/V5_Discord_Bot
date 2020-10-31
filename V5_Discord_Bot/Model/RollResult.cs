using System;
using System.Collections.Generic;

namespace V5_Discord_Bot.Model
{
    public class RollResult
    {
        private ICollection<int>? _normalDice;
        private ICollection<int>? _hungerDice;

        public ICollection<int> NormalDice
        {
            get => _normalDice ?? throw new InvalidOperationException("Uninitialized property: " + nameof(NormalDice));
            set => _normalDice = value;
        }

        public ICollection<int> HungerDice
        {
            get => _hungerDice ?? throw new InvalidOperationException("Uninitialized property: " + nameof(HungerDice));
            set => _hungerDice = value;
        }
    }
}