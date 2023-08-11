using UnityEngine;

namespace MPewsey.Decidutree.Subnodes
{
    /// <summary>
    /// Compares the modulo of the blackboard value to a specified value.
    /// </summary>
    public class ModuloSubnode : BehaviorSubnode
    {
        [SerializeField]
        private string _key;
        /// <summary>
        /// The blackboard key.
        /// </summary>
        public string Key { get => _key; set => _key = value; }

        [SerializeField]
        private int _modulus = 1;
        /// <summary>
        /// The modulus.
        /// </summary>
        public int Modulus { get => _modulus; set => _modulus = value == 0 ? 1 : value; }

        [SerializeField]
        private int _value;
        /// <summary>
        /// The compared value.
        /// </summary>
        public int Value { get => _value; set => _value = value; }

        [SerializeField]
        private ComparisonType _comparisonType;
        /// <summary>
        /// The comparison type.
        /// </summary>
        public ComparisonType ComparisonType { get => _comparisonType; set => _comparisonType = value; }

        /// <summary>
        /// The cached blackboard entry.
        /// </summary>
        public BlackboardEntry<int> Entry { get; private set; }

        /// <summary>
        /// Sets the values to the subnode and returns the subnode.
        /// </summary>
        /// <param name="key">The blackboard key.</param>
        /// <param name="modulus">The modulus.</param>
        /// <param name="value">The ompared value.</param>
        /// <param name="comparisonType">The comparison type.</param>
        public ModuloSubnode SetValues(string key, int modulus, int value, ComparisonType comparisonType)
        {
            Key = key;
            Modulus = modulus;
            Value = value;
            ComparisonType = comparisonType;
            return this;
        }

        private void OnValidate()
        {
            Modulus = Modulus;
        }

        /// <summary>
        /// Sets the blackboard entry to the subnode.
        /// </summary>
        protected override void OnInitialize()
        {
            Entry = Blackboard.EnsureSetValue(Key, 0);
        }

        /// <summary>
        /// Returns success if the comparison is satisfied. Otherwise, returns failure.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            if (Comparison.IsSatisfied(ComparisonType, Entry.Value % Modulus, Value))
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}