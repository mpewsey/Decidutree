namespace MPewsey.BehaviorTree
{
    /// <summary>
    /// Contains keys for blackboard entries registered by library components.
    /// </summary>
    public static class BlackboardKeys
    {
        /// <summary>
        /// The key corresponding to a tree's total tick count.
        /// </summary>
        public static string TickCount { get; } = "Tick Count";
    }
}