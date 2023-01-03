using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// Increments the specified blackboard entry.
    /// </summary>
    public class CounterSubnode : BehaviorSubnode
    {
        [SerializeField]
        private string _key = "<None>";
        /// <summary>
        /// The blackboard key.
        /// </summary>
        public string Key { get => _key; set => _key = value; }

        /// <summary>
        /// The incremented blackboard entry.
        /// </summary>
        public BlackboardEntry<int> Counter { get; private set; }

        /// <summary>
        /// Sets the values for the subnode and returns the subnode.
        /// </summary>
        /// <param name="key">The blackboard key.</param>
        public CounterSubnode SetValues(string key)
        {
            Key = key;
            return this;
        }

        /// <summary>
        /// Sets the blackboard entry for the counter to the subnode.
        /// </summary>
        protected override void OnInitialize()
        {
            Counter = Blackboard.SetValue(Key, 0);
        }

        /// <summary>
        /// Increments the counter and return success.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            Counter.Value = Mathf.Max(Counter.Value + 1, 0);
            return BehaviorStatus.Success;
        }
    }
}