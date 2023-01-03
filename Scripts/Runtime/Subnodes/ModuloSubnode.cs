using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    public class ModuloSubnode : BehaviorSubnode
    {
        [SerializeField]
        private string _key;
        public string Key { get => _key; set => _key = value; }

        [SerializeField]
        private int _modulus = 1;
        public int Modulus { get => _modulus; set => _modulus = value == 0 ? 1 : value; }

        [SerializeField]
        private int _value;
        public int Value { get => _value; set => _value = value; }

        public BlackboardEntry<int> Entry { get; private set; }

        public ModuloSubnode SetValues(string key, int modulus, int value)
        {
            Key = key;
            Modulus = modulus;
            Value = value;
            return this;
        }

        private void OnValidate()
        {
            Modulus = Modulus;
        }

        protected override void OnInitialize()
        {
            Entry = Blackboard.EnsureSetValue(Key, 0);
        }

        protected override BehaviorStatus OnTick()
        {
            if (Entry.Value % Modulus == Value)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}