using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2020.Day19.Logic
{
    internal class Consumer
    {
        private readonly string _message;
        private readonly Rule _rule;
        private readonly Rules _rules;
        private readonly List<int> _finalConsumedList;
        private readonly List<Action<List<int>>> _actions;
        private readonly List<int> _listOfAmountOfConsumedCharacters;
        private List<int> _recentlyConsumed;
        private bool _failedAttempt;

        public Consumer(string message, Rule rule, Rules rules)
        {
            _message = message;
            _rule = rule;
            _rules = rules;
            _recentlyConsumed = new List<int>();
            _finalConsumedList = new List<int>();
            _actions = new List<Action<List<int>>>();
            _listOfAmountOfConsumedCharacters = new List<int>();
        }

        public List<int> Consume()
        {
            if (MessageIsEmpty())
            {
                return _finalConsumedList;
            }

            if (RuleIsFinal())
            {
                AddRuleResolutionToConsumedList();
                return _finalConsumedList;
            }

            foreach (var subRule in _rule.SubRules)
            {
                InitializeSubRule();

                foreach (var id in subRule)
                {
                    foreach (var consumedCharacters in _listOfAmountOfConsumedCharacters)
                    {
                        ConsumeMessagesStartingFrom(consumedCharacters, id);

                        if (ConsumedCharactersSuccessfully())
                        {
                            QueueConsumedChangesAdding(consumedCharacters);
                        }
                        else
                        {
                            MarkAttemptAsFailedDeleting(consumedCharacters);
                        }
                    }

                    ApplyQueuedChangesToConsumedList();

                    if (AttemptMarkedAsFailed())
                    {
                        break;
                    }
                }

                if (AnyPathReachesTheSolution())
                {
                    return _listOfAmountOfConsumedCharacters;
                }

                StoreConsumedForNextCycle();
            }

            return _finalConsumedList;
        }

        private bool AttemptMarkedAsFailed() => _failedAttempt;

        private bool ConsumedCharactersSuccessfully() => _recentlyConsumed.Count > 0;

		// partial coverage as _rule.Character can never be null
        private void AddRuleResolutionToConsumedList() =>
            _finalConsumedList.Add(_message[0] == _rule.Character ? 1 : 0);

        private bool RuleIsFinal() => _rule.Character.HasValue;

        private void InitializeSubRule()
        {
            _listOfAmountOfConsumedCharacters.Add(0);
            _failedAttempt = false;
        }

        private void MarkAttemptAsFailedDeleting(int consumedCharacters)
        {
            _actions.Add(l => l.Remove(consumedCharacters));
            _failedAttempt = true;
        }

        private void ConsumeMessagesStartingFrom(int consumed, int id) =>
            _recentlyConsumed = _rules
                .ConsumesMessageWith(id, _message[consumed..])
                .Where(p => p > 0)
                .ToList();

        private void QueueConsumedChangesAdding(int consumed) =>
            _recentlyConsumed.ForEach(c => _actions.Add(l => l.Add(c + consumed)));

        private bool MessageIsEmpty() => string.IsNullOrEmpty(_message);

        private void ApplyQueuedChangesToConsumedList()
        {
            _listOfAmountOfConsumedCharacters.Clear();
            _actions.ForEach(a => a(_listOfAmountOfConsumedCharacters));
            _actions.Clear();
        }

        private bool AnyPathReachesTheSolution() => _listOfAmountOfConsumedCharacters.Any(p => p == _message.Length);

        private void StoreConsumedForNextCycle()
        {
            _finalConsumedList.AddRange(_listOfAmountOfConsumedCharacters);
            _listOfAmountOfConsumedCharacters.Clear();
        }
    }
}
