using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// Returns success if the modulo of the tick count is equal to a specified value.
    /// </summary>
    public class TickCountModIsValueSubnode : BehaviorSubnode
    {
        [SerializeField]
        private uint _modulus = 1;
        /// <summary>
        /// The modulus.
        /// </summary>
        public uint Modulus
        {
            get => _modulus;
            set => _modulus = System.Math.Max(value, 1);
        }

        [SerializeField]
        private uint _value;
        /// <summary>
        /// The equality value.
        /// </summary>
        public uint Value { get => _value; set => _value = value; }

        /// <summary>
        /// The tick count blackboard entry.
        /// </summary>
        public BlackboardEntry<uint> TickCount { get; private set; }

        private void OnValidate()
        {
            Modulus = Modulus;
        }

        /// <summary>
        /// Sets the tick count blackboard entry to the subnode.
        /// </summary>
        protected override void OnInitialize()
        {
            TickCount = Blackboard.EnsureSetValue(BlackboardKeys.TickCount, 0u);
        }

        /// <summary>
        /// Returns success if the modulo of the tick count is equal to a specified value.
        /// Otherwise, returns failure.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            if (TickCount.Value % Modulus == Value)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}