namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// Increments the tick count entry on the blackboard.
    /// </summary>
    public class TickCounterSubnode : BehaviorSubnode
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
            TickCount = Blackboard.SetValue(BlackboardKeys.TickCount, 0u);
        }

        /// <summary>
        /// Increments the tick count entry on the blackboard and returns Success.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            TickCount.Value++;
            return BehaviorStatus.Success;
        }
    }
}