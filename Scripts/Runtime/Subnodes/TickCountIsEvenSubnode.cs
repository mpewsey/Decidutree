namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// Returns success if the tick count blackboard entry is even.
    /// </summary>
    public class TickCountIsEvenSubnode : BehaviorSubnode
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
        /// Returns success if the tick count blackboard entry is even.
        /// Otherwise, returns failure.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            if (TickCount.Value % 2 == 0)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}