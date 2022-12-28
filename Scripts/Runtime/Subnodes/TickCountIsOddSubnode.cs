namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// Returns success if the tick count blackboard entry is odd.
    /// </summary>
    public class TickCountIsOddSubnode : BehaviorSubnode
    {
        /// <summary>
        /// The tick count blackboard entry.
        /// </summary>
        public BlackboardEntry<uint> TickCount { get; private set; }

        /// <summary>
        /// Sets the tick count blackboard entry to the subnode.
        /// </summary>
        protected override void OnInitialize()
        {
            TickCount = Blackboard.EnsureSetValue(BlackboardKeys.TickCount, 0u);
        }

        /// <summary>
        /// Returns success if the tick count blackboard entry is odd.
        /// Otherwise, returns failure.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            if (TickCount.Value % 2 == 1)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}