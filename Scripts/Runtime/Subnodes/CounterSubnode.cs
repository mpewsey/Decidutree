using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    public class CounterSubnode : BehaviorSubnode
    {
        [SerializeField]
        private string _key = "<None>";
        public string Key { get => _key; set => _key = value; }

        public BlackboardEntry<int> Counter { get; private set; }

        public CounterSubnode SetValues(string key)
        {
            Key = key;
            return this;
        }

        protected override void OnInitialize()
        {
            Counter = Blackboard.SetValue(Key, 0);
        }

        protected override BehaviorStatus OnTick()
        {
            Counter.Value = Mathf.Max(Counter.Value + 1, 0);
            return BehaviorStatus.Success;
        }
    }
}