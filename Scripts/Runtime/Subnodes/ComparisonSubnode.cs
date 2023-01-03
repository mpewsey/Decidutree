using System.Collections.Generic;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    public abstract class ComparisonSubnode<T> : BehaviorSubnode
    {
        [SerializeField]
        private string _key = "<None>";
        public string Key { get => _key; set => _key = value; }

        [SerializeField]
        private ComparisonType _comparison;
        public ComparisonType Comparison { get => _comparison; set => _comparison = value; }

        [SerializeField]
        private T _value;
        public T Value { get => _value; set => _value = value; }

        public BlackboardEntry<T> Entry { get; private set; }

        public ComparisonSubnode<T> SetValues(string key, ComparisonType comparison, T value)
        {
            Key = key;
            Comparison = comparison;
            Value = value;
            return this;
        }

        protected override void OnInitialize()
        {
            Entry = Blackboard.GetValue<T>(Key);
        }

        protected override BehaviorStatus OnTick()
        {
            if (ComparisonSatisfied())
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }

        private bool ComparisonSatisfied()
        {
            var comparison = Comparer<T>.Default.Compare(Entry.Value, Value);

            switch (Comparison)
            {
                case ComparisonType.Equals:
                    return comparison == 0;
                case ComparisonType.NotEqual:
                    return comparison != 0;
                case ComparisonType.LessThan:
                    return comparison < 0;
                case ComparisonType.LessThanOrEqual:
                    return comparison <= 0;
                case ComparisonType.GreaterThan:
                    return comparison > 0;
                case ComparisonType.GreaterThanOrEqual:
                    return comparison >= 0;
                default:
                    throw new System.ArgumentException($"Unhandled comparison type: {Comparison}.");
            }
        }
    }
}