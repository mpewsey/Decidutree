using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// Compares a blackboard value against a specified value.
    /// </summary>
    public abstract class ComparisonSubnode<T> : BehaviorSubnode
    {
        [SerializeField]
        private string _key = "<None>";
        /// <summary>
        /// The blackboard key.
        /// </summary>
        public string Key { get => _key; set => _key = value; }

        [SerializeField]
        private ComparisonType _comparisonType;
        /// <summary>
        /// The comparison type.
        /// </summary>
        public ComparisonType ComparisonType { get => _comparisonType; set => _comparisonType = value; }

        [SerializeField]
        private T _value;
        /// <summary>
        /// The comparison value.
        /// </summary>
        public T Value { get => _value; set => _value = value; }

        /// <summary>
        /// The cached blackboard entry.
        /// </summary>
        public BlackboardEntry<T> Entry { get; private set; }

        /// <summary>
        /// Sets the values for the subnode and returns the subnode.
        /// </summary>
        /// <param name="key">The blackboard key.</param>
        /// <param name="comparison">The comparison type.</param>
        /// <param name="value">The comparison value.</param>
        public ComparisonSubnode<T> SetValues(string key, ComparisonType comparison, T value)
        {
            Key = key;
            ComparisonType = comparison;
            Value = value;
            return this;
        }

        /// <summary>
        /// Sets the blackboard entry to the subnode.
        /// </summary>
        protected override void OnInitialize()
        {
            Entry = Blackboard.EnsureSetValue<T>(Key, default);
        }

        /// <summary>
        /// Returns success if the comparison is satisifed. Otherwise, returns failure.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            if (Comparison.IsSatisfied(ComparisonType, Entry.Value, Value))
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}