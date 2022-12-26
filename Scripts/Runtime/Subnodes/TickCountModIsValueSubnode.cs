using UnityEngine;

namespace MPewsey.BehaviorTree
{
    public class TickCountModIsValueSubnode : BehaviorSubnode
    {
        [SerializeField]
        private uint _modulus = 1;
        public uint Modulus
        {
            get => _modulus;
            set => _modulus = System.Math.Max(value, 1);
        }

        [SerializeField]
        private uint _value;
        public uint Value { get => _value; set => _value = value; }

        public BlackboardEntry<uint> TickCount { get; private set; }

        private void OnValidate()
        {
            Modulus = Modulus;
        }

        protected override void OnInitialize()
        {
            TickCount = Blackboard.EnsureSetValue(BlackboardKeys.TickCount, 0u);
        }

        protected override BehaviorStatus OnTick()
        {
            if (TickCount.Value % Modulus == Value)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}