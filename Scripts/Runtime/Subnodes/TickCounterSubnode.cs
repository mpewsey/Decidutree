namespace MPewsey.BehaviorTree
{
    public class TickCounterSubnode : BehaviorSubnode
    {
        public BlackboardEntry<uint> TickCount { get; private set; }

        protected override void OnInitialize()
        {
            TickCount = Blackboard.SetValue(BlackboardKeys.TickCount, 0u);
        }

        protected override BehaviorStatus OnTick()
        {
            TickCount.Value++;
            return BehaviorStatus.Success;
        }
    }
}