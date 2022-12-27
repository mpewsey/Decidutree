namespace MPewsey.BehaviorTree.Subnodes
{
    public class TickCountIsOddSubnode : BehaviorSubnode
    {
        public BlackboardEntry<uint> TickCount { get; private set; }

        protected override void OnInitialize()
        {
            TickCount = Blackboard.EnsureSetValue(BlackboardKeys.TickCount, 0u);
        }

        protected override BehaviorStatus OnTick()
        {
            if (TickCount.Value % 2 == 1)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}