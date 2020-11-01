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